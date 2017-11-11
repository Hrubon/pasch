using System.Collections.Generic;
using System.Text;


public class ProgramOutput
{
    static List<Output> outputs = new List<Output>();



    public static void RegisterOutput(Output output)
    {
        if (!outputs.Contains(output))
        {
            outputs.Add(output);
        }
    }


    public static void UnregisterOutput(Output output)
    {
        outputs.Remove(output);
    }



    public static void Info(string message, params object[] args)
    {
        foreach (var output in outputs)
        {
            output.Info(message, args);
        }
    }


    public static void Warning(string message, params object[] args)
    {
        foreach (var output in outputs)
        {
            output.Warning(message, args);
        }
    }


    public static void Error(string message, params object[] args)
    {
        foreach (var output in outputs)
        {
            output.Error(message, args);
        }
    }


    public static string FormatArray(object[] arr)
    {
        var output = new StringBuilder();
        foreach (var str in arr)
        {
            output.AppendFormat("{0}, ", str);
        }
        output.Remove(output.Length - 2, 2);

        return output.ToString();
    }
}