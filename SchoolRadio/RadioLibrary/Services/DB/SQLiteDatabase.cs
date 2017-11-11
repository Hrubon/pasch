using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


public class SQLiteDatabase : IBroadcastDatabase
{
    const string DT_FORMAT = "yyyy-MM-dd HH:mm:ss";


    SQLiteConnection connection;



    public IDbConnection Connection
    {
        get
        {
            return connection;
        }
    }

    public int StartOffset { get; private set; }
    public int EndOffset { get; private set; }



    public void Open()
    {
        connection.Open();
    }


    public void Close()
    {
        connection.Close();
    }


    private IDbCommand CreateCommand(string query, params object[] args)
    {
        string qry = string.Format(query, args);
        var cmd = connection.CreateCommand();
        cmd.CommandText = qry;
        return cmd;
    }


    private BroadcastInfo ReadBroadcastInfo(IDataReader reader)
    {
        int id = reader.GetInt32(reader.GetOrdinal("id"));
        string username = reader.GetString(reader.GetOrdinal("username"));
        DateTime startTime = reader.GetDateTime(reader.GetOrdinal("start_time"));
        int seconds = reader.GetInt32(reader.GetOrdinal("duration"));
        TimeSpan duration = TimeSpan.FromSeconds(seconds);
        string filename = reader["filename"] == null ? null : Convert.ToString(reader["filename"]);
        BroadcastType type = (BroadcastType)reader.GetInt32(reader.GetOrdinal("data_source_type"));
        MediaType mediaType = (MediaType)reader.GetInt32(reader.GetOrdinal("media_type"));
        string label = reader.GetString(reader.GetOrdinal("label"));

        return new BroadcastInfo(id, username, startTime, duration, type, mediaType, filename, label);
    }


    private BroadcastInfo[] ReadBroadcastInfos(IDataReader reader)
    {
        var data = new List<BroadcastInfo>();
        while (reader.Read())
        {
            var broadcast = ReadBroadcastInfo(reader);
            data.Add(broadcast);
        }

        return data.ToArray();
    }


    private void DeleteForeign(string table, int id)
    {
        int count = (int)CreateCommand("SELECT COUNT(*) FROM {0} WHERE id = {1};", table, id).
            ExecuteScalar();
        if (count > 1)
            CreateCommand("DELETE FROM {0} WHERE id = {1};", table, id).
                ExecuteNonQuery();
    }


    private IDataReader GetEntityById(string table, int id)
    {
        return CreateCommand("SELECT id FROM {0} WHERE id = {1};", table, id).
            ExecuteReader();
    }


    private long GetEntityId(string table, string column, string value)
    {
        object id = CreateCommand("SELECT id FROM {0} WHERE {1} = '{2}';",
            table, column, value).
            ExecuteScalar();
        if (id != null)
            return Convert.ToInt64(id);
        else
            return -1;
    }


    private long AddEntityIfNotExists(string table, string column, string value)
    {
        long id = GetEntityId(table, column, value);
        if (id != -1)
        {
            return id;
        }
        else
        {
            CreateCommand("INSERT INTO {0} ({1}) VALUES ('{2}');",
                table, column, value).
                ExecuteNonQuery();
            return connection.LastInsertRowId;
        }
    }



    public BroadcastInfo[] GetAll()
    {
        var reader = CreateCommand("SELECT * FROM broadcasts;").
            ExecuteReader();
        return ReadBroadcastInfos(reader);
    }


    public BroadcastInfo[] GetInterval(DateTime start, DateTime end)
    {
        // Extend interval by offsets on both sides
        var from = start.Subtract(new TimeSpan(0, 0, StartOffset));
        var to = end.AddSeconds(EndOffset);

        // Select all broadcasts in the given interval:
        // (b.start >= from && b.start <= to) ||
        // (from >= b.start && from <= b.end)
        // where b.end = (b.start + b.duration), duration is in seconds
        var reader = CreateCommand("SELECT * FROM broadcasts " +
                                   "WHERE (datetime(start_time) >= datetime('{0}')" +
                                   "AND datetime(start_time) <= datetime('{1}')) " +
                                   "OR (datetime(strftime('%s', start_time) + duration, 'unixepoch') >= datetime('{0}') " +
                                   "AND datetime(strftime('%s', start_time) + duration, 'unixepoch') <= datetime('{1}'));",
                                   from.ToString(DT_FORMAT), to.ToString(DT_FORMAT)).
                                   ExecuteReader();
        
        return ReadBroadcastInfos(reader);
    }


    public BroadcastInfo GetNowPlaying()
    {
        var from = DateTime.Now.Subtract(new TimeSpan(0, 0, 4));
        var to = DateTime.Now.Add(new TimeSpan(0, 0, 4));
        var reader = CreateCommand("SELECT * FROM broadcasts WHERE start_time BETWEEN '{0}' AND '{1}' LIMIT 1;", from.ToString(DT_FORMAT), to.ToString(DT_FORMAT)).ExecuteReader();

        if (reader.Read())
        {
            return ReadBroadcastInfo(reader);
        }

        return null;
    }


    public void Add(BroadcastInfo broadcast)
    {
        CreateCommand("INSERT INTO broadcasts " +
                      "(username, start_time, duration, data_source_type, media_type, filename, label) " +
                      "VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}');",
                      broadcast.Username, broadcast.StartTime.ToString(DT_FORMAT),
                      Math.Ceiling(broadcast.Duration.TotalSeconds), (int)broadcast.Type, (int)broadcast.MediaType,
                    (broadcast.Filename != null) ? "'" + broadcast.Filename + "'" : "NULL", broadcast.Label).
                      ExecuteNonQuery();

        broadcast.Id = (int)connection.LastInsertRowId;
    }


    public bool Edit(int id, DateTime newStartTime, string newLabel)
    {
        using (SQLiteTransaction trans = connection.BeginTransaction())
        {
            var count = Convert.ToUInt32(CreateCommand("SELECT COUNT(*) FROM broadcasts WHERE id = {0};", id).ExecuteScalar());

            if (count == 0)
                return false;

            CreateCommand("UPDATE broadcasts SET start_time = '{0}', label = '{1}' WHERE id = {2};", newStartTime.ToString(DT_FORMAT), newLabel, id).ExecuteNonQuery();

            trans.Commit();
        }

        return true;
    }


    public bool Remove(int id)
    {
        using (SQLiteTransaction trans = connection.BeginTransaction())
        {
            var count = Convert.ToUInt32(CreateCommand("SELECT COUNT(*) FROM broadcasts WHERE id = {0};", id).ExecuteScalar());

            if (count == 0)
                return false;

            CreateCommand("DELETE FROM broadcasts WHERE id = {0};", id).ExecuteNonQuery();

            trans.Commit();
        }

        return true;
    }



    public SQLiteDatabase(SQLiteConnection connection, int startOffset, int endOffset)
    {
        this.connection = connection;
        StartOffset = startOffset;
        EndOffset = endOffset;
    }
}