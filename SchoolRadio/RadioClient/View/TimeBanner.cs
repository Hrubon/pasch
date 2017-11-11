using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace RadioClient
{
    public partial class TimeBanner : UserControl
    {
        Timer ticker;



        public DateTime Time { get; private set; }
        public char Splitter { get; set; }
        public string NAString { get; set; }
        public int Step
        {
            get
            {
                return ticker.Interval;
            }
            set
            {
                ticker.Interval = value;
            }
        }
        public bool NA { get; private set; }



        private string GetLongFormat(int value)
        {
            if (NA)
                return NAString;
            if (value < 10)
                return string.Format("0{0}", value);
            else if (value >= 100)
                return value.ToString().Substring(0, 2);
            else
                return value.ToString();
        }


        private void Redraw()
        {
            var image = new Bitmap(this.Size.Width, this.Size.Height);
            var drawer = Graphics.FromImage(image);
            drawer.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            string minute = GetLongFormat(Time.Minute);
            string second = GetLongFormat(Time.Second);
            string milisecond = GetLongFormat(Time.Millisecond);
            var w1 = drawer.MeasureString(minute, Font).Width;
            var w2 = drawer.MeasureString(second, Font).Width;
            var w3 = drawer.MeasureString(milisecond, Font).Width;
            var ws = drawer.MeasureString(Splitter.ToString(), Font).Width;
            var wt = w1 + w2 + w3 + 2 * ws;
            var xstart = (this.Width - wt) / 2;
            var y = (this.Height - drawer.MeasureString(minute, Font).Height) / 2;

            var b = new SolidBrush(ForeColor);
            drawer.DrawString(minute, Font, b, xstart, y);
            drawer.DrawString(Splitter.ToString(), Font, b, xstart + w1, y);
            drawer.DrawString(second, Font, b, xstart + w1 + ws, y);
            drawer.DrawString(Splitter.ToString(), Font, b, xstart + w1 + ws + w2, y);
            drawer.DrawString(milisecond, Font, b, xstart + w1 + ws + w2 + ws, y);

            this.BackgroundImage = image;
        }


        public void Start()
        {
            ticker.Start();
            NA = false;
        }


        public void Stop()
        {
            ticker.Stop();
            NA = false;
        }


        public void Reset()
        {
            Time = new DateTime();
            NA = false;
            Redraw();
        }


        public void SetNA()
        {
            NA = true;
            Redraw();
        }


        public void UnsetNA()
        {
            NA = false;
            Redraw();
        }


        private void TimeBanner_Load(object sender, EventArgs e)
        {
            Redraw();
        }


        private void Ticker_Tick(object sender, EventArgs e)
        {
            Time = Time.AddMilliseconds(ticker.Interval);
            Redraw();
        }


        private void TimeBanner_ForeColorChanged(object sender, EventArgs e)
        {
            Redraw();
        }



        public TimeBanner()
        {
            InitializeComponent();
            ticker = new Timer();
            ticker.Tick += Ticker_Tick;
        }
    }
}
