using SkiaSharp;
using System.Runtime.Serialization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly int W = 700;
        private static readonly int H = 500;
        private static readonly int XDIV = 50;
        private static readonly int YDIV = 35;
        private static readonly int HLENGTH = W / XDIV;
        private static readonly int VLENGTH = H / YDIV;
        private static readonly int MIN_X = -1 * XDIV / 2;
        private static readonly int MIN_Y = -1 * YDIV / 2;
        private static readonly int MAX_X = 1 * XDIV / 2;
        private static readonly int MAX_Y = 1 * YDIV / 2;

        public int x1 { get; set; } = 0;
        public int x2 { get; set; } = 0;

        public int y1 { get; set; } = 0;
        public int y2 { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            metodeChoices.SelectedIndex = 0;

            x1Field.Minimum = MIN_X;
            x1Field.Maximum = MAX_X;

            x2Field.Minimum = MIN_X;
            x2Field.Maximum = MAX_X;

            y1Field.Minimum = MIN_Y;
            y1Field.Maximum = MAX_Y;

            y2Field.Minimum = MIN_Y;
            y2Field.Maximum = MAX_Y;

            x1Field.Value = 0;
            y1Field.Value = 0;

            x2Field.Value = 10;
            y2Field.Value = 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SKImageInfo imageInfo = new SKImageInfo(W, H, SKColorType.Rgba8888, SKAlphaType.Premul);
                using (SKSurface surface = SKSurface.Create(imageInfo))
                {
                    SKCanvas canvas = surface.Canvas;
                    canvas.Clear(SKColor.Parse("ccc"));
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Color = SKColors.Blue;
                        paint.StrokeWidth = 15;
                        paint.Style = SKPaintStyle.Stroke;

                        DrawGrid(canvas);
                        int x1 = Convert.ToInt32(x1Field.Value) + XDIV / 2;
                        int x2 = Convert.ToInt32(x2Field.Value) + XDIV / 2;
                        int y1 = (YDIV / 2) - Convert.ToInt32(y1Field.Value);
                        int y2 = (YDIV / 2) - Convert.ToInt32(y2Field.Value);
                        SKPoint p0 = new SKPoint(x1, y1);
                        SKPoint p1 = new SKPoint(x2, y2);
                        //var p0 = new SKPoint(0, 0);
                        //var p1 = new SKPoint(12, 8);
                        //if (p0.X > p1.X)
                        //{
                        //    var _p = p0;
                        //    p0 = p1;
                        //    p1 = _p;
                        //}
                        var method = metodeChoices.SelectedItem == null ? "Brute Force" : metodeChoices.SelectedItem;
                        // var method = "DDA";
                        DrawLine((string)method, canvas, p0, p1);
                    }
                    using (SKImage image = surface.Snapshot())
                    using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (MemoryStream mStream = new MemoryStream(data.ToArray()))
                    {
                        Bitmap bitmap = new Bitmap(mStream, false);
                        pictureBox1.Image = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        protected static void DrawGrid(SKCanvas canvas)
        {
            var xDiv = XDIV;
            var yDiv = YDIV;
            var hlength = HLENGTH;
            var vlength = VLENGTH;
            var hcenter = W / 2;
            var vcenter = H / 2;

            using (SKPaint paint = new SKPaint())
            using (SKPaint boldPaint = new SKPaint())
            {
                paint.Color = SKColor.Parse("bbb");
                paint.StrokeWidth = 1;
                paint.Style = SKPaintStyle.Stroke;

                boldPaint.Color = SKColor.Parse("bbb");
                boldPaint.StrokeWidth = 2;
                boldPaint.Style = SKPaintStyle.Stroke;

                //canvas.DrawLine(
                //    new SKPoint(hcenter, 0),
                //    new SKPoint(hcenter, H),
                //    boldPaint
                //);
                canvas.DrawLine(
                    new SKPoint((xDiv + 0) / 2 * vlength, 0),
                    new SKPoint((xDiv + 0) / 2 * vlength, H),
                    boldPaint
                );
                canvas.DrawLine(
                    new SKPoint(0, ((yDiv / 2) + 0) * hlength),
                    new SKPoint(W, ((yDiv / 2) + 0) * hlength),
                    boldPaint
                );

                using (SKPaint textPaint = new SKPaint())
                {
                    textPaint.Color = SKColor.Parse("222");
                    textPaint.TextSize = 12.0f;
                    textPaint.IsAntialias = true;
                    textPaint.IsStroke = false;
                    canvas.DrawText("0,0", xDiv / 2 * vlength, yDiv / 2 * hlength, textPaint);
                }

                for (int i = 1; i < xDiv; i++)
                {
                    canvas.DrawLine(
                        new SKPoint(i * hlength, H),
                        new SKPoint(i * hlength, 0),
                        paint
                    );
                }
                for (int i = 1; i < yDiv; i++)
                {
                    var sect = i * vlength;
                    canvas.DrawLine(
                        new SKPoint(0, sect),
                        new SKPoint(W, sect),
                        paint
                    );
                }
            }
        }

        protected static void DrawLine(string method, SKCanvas canvas, SKPoint p0, SKPoint p1)
        {
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = new SKColor(252, 186, 3, 100);
                paint.StrokeWidth = 1;
                paint.Style = SKPaintStyle.Fill;

                if (method == "Brute Force")
                {
                    BruteForcePlotLine(canvas, paint, p0, p1);
                }
                else if (method == "Bressenham")
                {
                    BressenhamPlotLine(canvas, paint, p0, p1);
                }
                else if (method == "DDA")
                {
                    DDAPlotLine(canvas, paint, p0, p1);
                }
            }
        }

        protected static void BressenhamPlotLineLow(SKCanvas canvas, SKPaint paint, SKPoint p0, SKPoint p1)
        {
            var dx = (p1.X - p0.X);
            var dy = (p1.Y - p0.Y);
            var yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            var D = (2 * dy) - dx;
            var y = p0.Y;
            var start = (int)p0.X;
            for (int i = start; i < p1.X; i++)
            {
                DrawPixel(canvas, paint, i, (int)y);
                if (D > 0)
                {
                    y = y + yi;
                    D = D + (2 * (dy - dx));
                }
                else
                {
                    D = D + (2 * dy);
                }
            }
        }

        protected static void BressenhamPlotLineHigh(SKCanvas canvas, SKPaint paint, SKPoint p0, SKPoint p1)
        {
            var dx = (p1.X - p0.X);
            var dy = (p1.Y - p0.Y);
            var xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            var D = (2 * dx) - dy;
            var x = p0.X;
            var start = (int)p0.Y;
            for (int i = start; i < p1.Y; i++)
            {
                DrawPixel(canvas, paint, (int)x, i);
                if (D > 0)
                {
                    x = x + xi;
                    D = D + (2 * (dx - dy));
                }
                else
                {
                    D = D + (2 * dy);
                }
            }
        }

        protected static void BressenhamPlotLine(SKCanvas canvas, SKPaint paint, SKPoint p0, SKPoint p1)
        {
            if (Math.Abs(p1.Y - p0.Y) < Math.Abs(p1.X - p0.X))
            {
                if (p0.X > p1.X)
                {
                    BressenhamPlotLineLow(canvas, paint, p1, p0);
                }
                else
                {
                    BressenhamPlotLineLow(canvas, paint, p0, p1);
                }
            }
            else
            {
                if (p0.Y > p1.Y)
                {
                    BressenhamPlotLineHigh(canvas, paint, p1, p0);
                }
                else
                {
                    BressenhamPlotLineHigh(canvas, paint, p0, p1);
                }
            }
        }

        protected static void DDAPlotLine(SKCanvas canvas, SKPaint paint, SKPoint p0, SKPoint p1)
        {
            // Calculate dx and dy 
            var dx = p1.X - p0.X;
            var dy = p1.Y - p0.Y;

            int step;

            // If dx > dy we will take step as dx 
            // else we will take step as dy to draw the complete 
            // line 
            if (Math.Abs(dx) > Math.Abs(dy))
                step = (int)Math.Abs(dx);
            else
                step = (int)Math.Abs(dy);

            // Calculate x-increment and y-increment for each 
            // step 
            float x_incr = (float)dx / step;
            float y_incr = (float)dy / step;

            // Take the initial points as x and y 
            float x = p0.X;
            float y = p0.Y;

            for (int i = 0; i < step; i++)
            {

                DrawPixel(canvas, paint, (int)x, (int)y);
                x += x_incr;
                y += y_incr;
                // delay(10); 
            }
        }

        protected static void BruteForcePlotLine(SKCanvas canvas, SKPaint sKPaint, SKPoint p0, SKPoint p1)
        {
            var m = (p1.Y - p0.Y) / (p1.X - p0.X);
            var N = p1.X - p0.X + 1;
            var x = p0.X;
            for (int i = 0; i < N; i++)
            {
                var y = m * (x - p0.X) + p0.Y;
                float ya = Round(y);
                DrawPixel(canvas, sKPaint, (int)x, (int)y);
                x += 1;
            }
        }

        protected static void DrawPixel(SKCanvas canvas, SKPaint paint, int x, int y)
        {
            var _x = (int)(x * HLENGTH);
            var _y = (int)(y * VLENGTH);
            var rect = new SKRect(_x, _y, _x + HLENGTH, _y + VLENGTH);
            canvas.DrawRect(rect, paint);
        }

        protected static (int, int) ConvertGridToRealCoordintates(int x, int y)
        {
            return (x * HLENGTH, y * VLENGTH);
        }

        private void y2Field_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static int Round(float n)
        {
            if (n - (int)n < 0.5)
                return (int)n;
            return (int)(n + 1);
        }

        private void x2Field_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
