using System;
using System.Windows.Forms;


namespace RadioClient
{
    public partial class MainForm : Form
    {
        RequestSender sender;


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.sender = MasterContainer.GetService<RequestSender>();


            //var start = timeLine1.StartTime.AddMinutes(2);
            //var end = timeLine1.StartTime.AddMinutes(8);

            //var tasks = new TimeLineTask[] {
            //    new TimeLineTask(start, end, "V. Klínská"),
            //    new TimeLineTask(start.AddMinutes(3), end.AddMinutes(1), "M. Kaufmann") };

            //timeLine1.SetTasks(tasks);
        }

        private void btnRecordBroadcast_Click(object sender, EventArgs e)
        {
            BroadcastForm addForm = new BroadcastForm();
            addForm.ShowRecOnLoad = true;
            addForm.ShowDialog();

            BroadcastForm brdForm = new BroadcastForm();

        }


        private void btnPlanBroadcast_Click(object sender, EventArgs e)
        {
            BroadcastForm form = new BroadcastForm();
            form.ShowDialog();
        }


        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            CalendarForm form = new CalendarForm();
            form.ShowDialog();
        }


        private void btnLiveBroadcast_Click(object sender, EventArgs e)
        {
            LiveBroadcastForm form = new LiveBroadcastForm();
            form.ShowDialog();
        }



        public MainForm()
        {
            InitializeComponent();
        }
    }
}
