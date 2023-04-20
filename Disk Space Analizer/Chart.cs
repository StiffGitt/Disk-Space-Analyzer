using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab6
{
    public class Chart
    {
        private readonly Dictionary<string, int> inFilesCount;
        private readonly Dictionary<string, long> inFilesSize;
        private Dictionary<string, long> outFilesCount;
        private Dictionary<string, long> outFilesSize;
        bool isLog;
        public Bitmap Bitmap { get; set; }

        private int colorRange;
        private Color backgroundColor = Color.White;
        private Color chartBackgroundColor = Color.LightGray;
        private Color linesColor = Color.Black;
        private Color[] chartColors;

        public Chart(Dictionary<string, int> inFilesCount, Dictionary<string, long> inFilesSize, int width, int height, int opt)
        {
            if (opt == 1)
                isLog = true;
            else
                isLog = false;
            this.inFilesCount = inFilesCount;
            this.inFilesSize = inFilesSize;
            Bitmap = new Bitmap(width, height);
            if (inFilesCount.Count > 10)
            {
                PrepareData();
                colorRange = 10;
            }
            else
            {
                outFilesCount = inFilesCount.ToDictionary(pair => pair.Key, pair => (long)pair.Value);
                outFilesSize = inFilesSize;
                colorRange = Math.Max(inFilesCount.Count, inFilesSize.Count);
            }
            GetColors();
            Draw(opt);
        }
        public void Draw(int opt)
        {
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                g.Clear(backgroundColor);
                int xOff = Bitmap.Width / 15;
                int yOff = Bitmap.Height / 30;
                int drawWidth = (Bitmap.Width - 3 * xOff) / 2;
                int drawHeight = Bitmap.Height - yOff;
                if (opt < 2)
                {
                    DrawBarChart(g, xOff, yOff, xOff + drawWidth, yOff + drawHeight, outFilesCount);
                    DrawBarChart(g, xOff * 2 + drawWidth, yOff, xOff * 2 + 2 * drawWidth, yOff + drawHeight, outFilesSize);
                }
                else if (opt == 2)
                {
                    DrawPieChart(g, xOff, yOff, xOff + drawWidth, yOff + drawHeight, outFilesCount, false);
                    DrawPieChart(g, xOff * 2 + drawWidth, yOff, xOff * 2 + 2 * drawWidth, yOff + drawHeight, outFilesSize, true);

                }
            }
        }
        private void GetColors()
        {
            chartColors = new Color[colorRange];
            for (int i = 0; i < colorRange; i++)
            {
                chartColors[i] = ColorFromHSV((360 / colorRange) * i, 1.0f, 1.0f);
            }
        }
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        } // https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        private void PrepareData()
        {

            var tempDir = new Dictionary<string, int>(inFilesCount.OrderByDescending(pair => pair.Value).Take(9));
            outFilesCount = tempDir.ToDictionary(pair => pair.Key, pair => (long)pair.Value);
            var othersSum = inFilesCount.OrderByDescending(pair => pair.Value).Skip(9).Sum(pair => pair.Value);
            outFilesCount.Add("others", othersSum);

            outFilesSize = new Dictionary<string, long>(inFilesSize.OrderByDescending(pair => pair.Value).Take(9));
            var othersSizeSum = inFilesSize.OrderByDescending(pair => pair.Value).Skip(9).Sum(pair => pair.Value);
            outFilesSize.Add("others", othersSizeSum);
        }
        private SolidBrush[] GetBarBrushes()
        {
            SolidBrush[] barBrushes = new SolidBrush[colorRange];
            for (int p = 0; p < colorRange; p++)
                barBrushes[p] = new SolidBrush(chartColors[p]);
            return barBrushes;
        }
        public void DrawBarChart(Graphics g, int x1, int y1, int x2, int y2, Dictionary<string, long> bars)
        {
            int width = x2 - x1;
            int height = y2 - y1;
            int leftMargin = 30;
            int bottomMargin = 5;
            int barsCount = bars.Count;
            int leftEdge = x1 + leftMargin;
            int rightEdge = x2;
            int bottomEdge = height - bottomMargin;
            int topEdge = y1;
            int graphHeight = bottomEdge - topEdge;
            int graphWidth = rightEdge - leftEdge;
            double upScale = (isLog) ? Math.Log10(bars.Max(pair => pair.Value) * 10) :
                bars.Max(pair => pair.Value) + (long)bars.Average(pair => pair.Value) / 4;

            SolidBrush backGroundBrush = new SolidBrush(chartBackgroundColor);
            SolidBrush textBrush = new SolidBrush(linesColor);
            Pen linePen = new Pen(linesColor);
            SolidBrush[] barBrushes = GetBarBrushes();

            g.FillRectangle(backGroundBrush, new Rectangle(leftEdge, topEdge, graphWidth, graphHeight));

            int scaleLines = 10;
            double offScale = upScale / scaleLines;
            //MessageBox.Show(offScale.ToString());
            int offLine = graphHeight / scaleLines;

            for (int j = 0; j <= scaleLines; j++)
            {
                long scaleVal = (isLog) ? (long)Math.Pow(10, offScale * j) : (long)(offScale * j);
                int scalePos = offLine * j;
                g.DrawLine(linePen, leftEdge, topEdge + graphHeight - scalePos, leftEdge + graphWidth, topEdge + graphHeight - scalePos);
                using (Font font = new Font(SystemFonts.DefaultFont.FontFamily, 7))
                {
                    var size = g.MeasureString(Functions.ConvertToScientificNotation(scaleVal), font);
                    Point point1 = new Point(x1 + (leftMargin - (int)size.Width), topEdge + graphHeight - scalePos - 3);
                    g.DrawString(Functions.ConvertToScientificNotation(scaleVal), font, textBrush, point1);
                    //g.DrawString(scaleVal.ToString(), font, textBrush, point1);
                }
            }
            int barWidth = graphWidth / (2 * barsCount + 1);
            int sideOff = (graphWidth - barWidth * (2 * barsCount + 1)) / 2;
            //if (bars.Count == 1)
            //{
            //    barWidth /= 2;
            //    sideOff = barWidth / 2;
            //}
            int spaceWidth = barWidth;
            int i = 0;
            foreach (var item in bars)
            {
                double barHeight = (isLog) ? (Math.Log10(item.Value) * graphHeight) / upScale : (item.Value * graphHeight) / upScale;
                Rectangle bar = new Rectangle(sideOff + leftEdge + i * barWidth + (i + 1) * spaceWidth, topEdge + graphHeight - (int)barHeight, barWidth, (int)barHeight);
                g.FillRectangle(barBrushes[i], bar);
                g.DrawRectangle(linePen, bar);

                using (Font font = new Font(SystemFonts.DefaultFont.FontFamily, 7))
                {
                    Point point1 = new Point(bar.X, bar.Y + bar.Height + 2);
                    g.DrawString(item.Key, font, textBrush, point1);
                }

                i++;
            }
        }

        

        public void DrawPieChart(Graphics g, int x1, int y1, int x2, int y2, Dictionary<string, long> bars, bool isSize)
        {
            int width = x2 - x1;
            int height = y2 - y1;
            int bottomMargin = height / 5;
            int legendWidth = width / 4;
            int barsCount = bars.Count;
            int leftEdge = x1;
            int rightEdge = x2 - legendWidth;
            int bottomEdge = height - bottomMargin;
            int topEdge = y1;
            int graphHeight = bottomEdge - topEdge;
            int graphWidth = rightEdge - leftEdge;
            int circleSize = Math.Min(graphHeight, graphWidth);
            float upScale = bars.Sum(pair => pair.Value);

            int legendLeftEdge = rightEdge + 5;
            int legendTopEdge = topEdge;
            int legendRectWidth = legendWidth / 4;
            int legendRectHeight = 15;
            int legendOffY = legendRectHeight / 2;


            SolidBrush backGroundBrush = new SolidBrush(chartBackgroundColor);
            SolidBrush textBrush = new SolidBrush(linesColor);
            Pen linePen = new Pen(linesColor, 1);
            Pen legendLinePen = new Pen(linesColor);
            SolidBrush[] pieBrushes = GetBarBrushes();

            int barWidth = graphWidth / (2 * barsCount + 1);
            int sideOff = (graphWidth - barWidth * (2 * barsCount + 1)) / 2;
            //if (bars.Count == 1)
            //{
            //    barWidth /= 2;
            //    sideOff = barWidth / 2;
            //}
            int spaceWidth = barWidth;
            int i = 0;
            float currentAngle = 0.0F;
            Rectangle rect = new Rectangle(leftEdge, topEdge, circleSize, circleSize);
            foreach (var item in bars)
            {
                float sweepAngle = item.Value / upScale * 360;

                g.FillPie(pieBrushes[i], rect, currentAngle, sweepAngle);
                g.DrawPie(linePen, rect, currentAngle, sweepAngle);
                currentAngle += sweepAngle;

                Rectangle legendRect = new Rectangle(legendLeftEdge, legendTopEdge + i * (legendOffY + legendRectHeight),
                    legendRectWidth, legendRectHeight);
                g.FillRectangle(pieBrushes[i], legendRect);
                g.DrawRectangle(legendLinePen, legendRect);

                string s = item.Key + " - " + ((isSize) ? Functions.SizeToString(item.Value) : Functions.ConvertToScientificNotation(item.Value));
                using (Font font = new Font(SystemFonts.DefaultFont.FontFamily, 7))
                {
                    Point point1 = new Point(legendRect.X + legendRect.Width * 7 / 6, legendRect.Y);
                    g.DrawString(s, font, textBrush, point1);
                }

                i++;
            }

        }
    }
}
