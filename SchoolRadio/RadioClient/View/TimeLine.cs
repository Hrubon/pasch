using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;


namespace RadioClient
{
    public partial class TimeLine : UserControl
    {
        const int TEN_MINUTES = 10,
                     ONE_HOUR = 1,
                     ONE_DAY = 1;



        private TimeLineTask[] tasks;
        private Label[] labels;
        private TimeLineTask selected;
        public TimeLineTask SelectedTask
        {
            get
            {
                return selected;
            }
            set
            {
                if (value != selected)
                {
                    selected = value;
                    Redraw();
                    if (SelectionChanged != null)
                        SelectionChanged(selected, selected == null);
                }
            }
        }
        public bool IsSelectionEmpty
        {
            get
            {
                return (SelectedTask == null);
            }
        }



        public DateTime StartTime { get; set; }
        public int MinutesInterval { get; set; }
        public int LabelsCount { get; set; }
        public DateTime EndTime
        {
            get
            {
                return StartTime.AddMinutes(LabelsCount * MinutesInterval);
            }
        }
        public bool ReadOnly { get; set; }


        private Color headerBackColor;
        public Color HeaderBackColor
        {
            get
            {
                return headerBackColor;
            }
            set
            {
                headerBackColor = value;
                pnlLabels.BackColor = headerBackColor;
            }
        }
        public int LabelsOffset { get; set; }
        public Font LabelsFont { get; set; }
        public Color LabelFontColor { get; set; }

        public bool DrawLines { get; set; }
        public Color LinesColor { get; set; }

        private Color bodyBackColor;
        public Color BodyBackColor
        {
            get
            {
                return bodyBackColor;
            }
            set
            {
                bodyBackColor = value;
                pnlContent.BackColor = bodyBackColor;
            }
        }
        public int ContentOffset { get; set; }
        public Color TaskColor { get; set; }
        public Color SelectedTaskColor { get; set; }
        public int TaskAlpha { get; set; }
        public int SelectedTaskAlpha { get; set; }
        public Font ContentFont { get; set; }
        public Color ContentFontColor { get; set; }



        public delegate void SelectionChangedEventHandler(TimeLineTask selected, bool isEmpty);
        public event SelectionChangedEventHandler SelectionChanged;



        public void ClearSelection()
        {
            SelectedTask = null;
        }


        public void SetTasks(BroadcastInfo[] tasks)
        {
            this.tasks = new TimeLineTask[tasks.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                this.tasks[i] = new TimeLineTask(tasks[i]);
            }
            Redraw();
        }


        public void Redraw()
        {
            ReloadLabels();

            Image image = new Bitmap(pnlContent.Size.Width, pnlContent.Size.Height);
            Graphics drawer = Graphics.FromImage(image);
            drawer.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Draw tasks
            foreach (TimeLineTask task in tasks)
            {
                // If task is not out of bounds of the current view
                if (task.Task.EndTime >= StartTime && task.Task.StartTime < EndTime)
                {
                    // Draw rectangle
                    DateTime start = GetMax(StartTime, task.Task.StartTime);
                    DateTime end = GetMin(EndTime, task.Task.EndTime);
                    var b = (task == SelectedTask) ? new SolidBrush(Color.FromArgb(SelectedTaskAlpha, SelectedTaskColor)) :
                        new SolidBrush(Color.FromArgb(TaskAlpha, TaskColor));
                    int x1 = GetX(start);
                    int x2 = GetX(end);
                    int y = 0;
                    int w = x2 - x1;
                    int h = pnlContent.Size.Height;
                    drawer.FillRectangle(b, x1, y, w, h);

                    // Store X coordinates to task object, to make the task "clickable"
                    task.XStart = x1;
                    task.XEnd = x2;

                    // Draw texts
                    string startLabel = task.Task.StartTime.ToShortTimeString();
                    string endLabel = task.Task.EndTime.ToShortTimeString();
                    string content1 = task.Task.Username;
                    string content2 = task.Task.Label;
                    var timeLabelSize = drawer.MeasureString(startLabel, ContentFont);
                    var content1LabelSize = drawer.MeasureString(content1, ContentFont);
                    var content2LabelSize = drawer.MeasureString(content2, ContentFont);
                    int timeLabelW = (int)timeLabelSize.Width;
                    int timeLabelH = (int)timeLabelSize.Height;
                    int content1LabelW = (int)content1LabelSize.Width;
                    int content2LabelW = (int)content2LabelSize.Width;
                    Brush contentBrush = new SolidBrush(ContentFontColor);
                    if (2 * (timeLabelW + LabelsOffset) <= w)
                    {
                        drawer.DrawString(startLabel, ContentFont, contentBrush, x1 + ContentOffset, ContentOffset);
                        drawer.DrawString(endLabel, ContentFont, contentBrush, x2 - timeLabelW - ContentOffset, timeLabelH + 2 * ContentOffset);
                    }
                    if (content1LabelW + ContentOffset <= w)
                    {
                        drawer.DrawString(content1, ContentFont, contentBrush, x1 + ContentOffset, 2 * (timeLabelH + ContentOffset));
                    }
                    if (content2LabelW + ContentOffset <= w)
                    {
                        drawer.DrawString(content2, ContentFont, contentBrush, x1 + ContentOffset, 3 * (timeLabelH + ContentOffset));
                    }
                }
            }

            // Draw timeline label lines
            if (DrawLines)
            {
                for (int i = 0; i < LabelsCount; i++)
                {
                    var p = new Pen(LinesColor);
                    int x1 = i * (pnlContent.Size.Width / (LabelsCount - 1));
                    int y1 = 0;
                    int x2 = x1;
                    int y2 = pnlContent.Size.Height;

                    drawer.DrawLine(p, x1, y1, x2, y2);
                }
            }

            pnlContent.BackgroundImage = image;
        }



        private DateTime GetMax(DateTime dt1, DateTime dt2)
        {
            return (dt1.CompareTo(dt2) >= 0) ? dt1 : dt2;
        }


        private DateTime GetMin(DateTime dt1, DateTime dt2)
        {
            return (dt1.CompareTo(dt2) <= 0) ? dt1 : dt2;
        }


        private int GetX(DateTime dt)
        {
            int minuteLength = (LabelsCount - 1) * MinutesInterval;
            int minuteDelta = Convert.ToInt32(dt.Subtract(StartTime).TotalMinutes);
            double ratio = minuteDelta / (double)minuteLength;
            return (int)(pnlContent.Size.Width * ratio);
        }


        private void InitLabels()
        {
            labels = new Label[LabelsCount];
            for (int i = 0; i < LabelsCount; i++)
            {
                labels[i] = new Label();
                pnlLabels.Controls.Add(labels[i]);
            }
        }


        private void ReloadLabels()
        {
            for (int i = 0; i < LabelsCount; i++)
            {
                Label label = labels[i];
                label.Text = StartTime.AddMinutes(i * MinutesInterval).ToShortTimeString();
                label.Font = LabelsFont;
                label.ForeColor = LabelFontColor;
                label.AutoSize = true;
                int x = LabelsOffset + i * (pnlLabels.Size.Width - label.Size.Width - 2 * LabelsOffset) / (LabelsCount - 1);
                label.Location = new Point(x, pnlLabels.Size.Height / 2 - label.Size.Height / 2);
            }
        }


        private void SetValueFromPickers()
        {
            StartTime = dtpDate.Value.Date.Add(dtpTime.Value.TimeOfDay);
        }



        private void TimeLine_Load(object sender, EventArgs e)
        {
            InitLabels();
        }

        private void pnlContent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !ReadOnly)
            {
                foreach (var task in tasks)
                {
                    if (e.X > task.XStart && e.X < task.XEnd)
                    {
                        SelectedTask = task;
                        break;
                    }
                    SelectedTask = null;
                }
            }
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            SetValueFromPickers();
            Redraw();
        }

        private void btnPlus10Minutes_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.AddMinutes(TEN_MINUTES);
            Redraw();
        }

        private void btnMinus10Minutes_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.Subtract(new TimeSpan(0, TEN_MINUTES, 0));
            Redraw();
        }

        private void btnPlus1Hour_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.AddHours(ONE_HOUR);
            Redraw();
        }

        private void btnMinus1Hour_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.Subtract(new TimeSpan(ONE_HOUR, 0, 0));
            Redraw();
        }

        private void btnPlus1Day_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.AddDays(ONE_DAY);
            Redraw();
        }

        private void btnMinus1Day_Click(object sender, EventArgs e)
        {
            StartTime = StartTime.Subtract(new TimeSpan(ONE_DAY, 0, 0, 0));
            Redraw();
        }



        public TimeLine()
        {
            InitializeComponent();
        }
    }
}
