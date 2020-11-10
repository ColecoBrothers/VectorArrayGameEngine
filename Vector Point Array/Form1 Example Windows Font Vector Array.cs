using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Vector_Point_Array
{

    public partial class Form1 : Form
    {
        // timner vars
        const int tickResolution = 10;
        long lPaintTime = 0;
        int timerTick = 0;

        // ship vars
        float fRotation = 0;
        float fThrust = 0;
        float fVelocity = 0;
        PointF pPosition = new PointF(0, 0);

        bool KeyUP = false;
        bool KeyDWN = false;
        bool KeyLFT = false;
        bool KeyRT = false;
        bool KeySpc = false;

        //phaser vars
        int phaserIndex = 0;
        Pulse[] phaser = new Pulse[4];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < phaser.Length; i++)
            {
                Pulse tmpPhaser = new Pulse();
                tmpPhaser.bEnabled = false;
                tmpPhaser.fMomentumVelocity = 0;
                tmpPhaser.fMomentumAngle = 0;
                tmpPhaser.fScale = 1;
                phaser[i] = tmpPhaser;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Stopwatch _st = new System.Diagnostics.Stopwatch();
            _st.Start();

            Bitmap bmp = new Bitmap(picDisplayArea.Width, picDisplayArea.Height);
            GraphicsPath gp = new GraphicsPath();
            PointF pVelocity = new PointF(0, 0);

            if (fVelocity > 0)
            {
                // Create points that define pulse.
                int iLenght = 10;
                pVelocity = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(fRotation + 90), iLenght);
                pVelocity.X = pVelocity.X *= (fVelocity / 10);
                pVelocity.Y = pVelocity.Y *= (fVelocity / 10);
            }
            pPosition.X += pVelocity.X;
            pPosition.Y += pVelocity.Y;

            // Y 
            using (Font f = new Font("Tahoma", 24f))
            {
                gp.AddString("Y", f.FontFamily, 0, 24f, new Point(-11, -11), StringFormat.GenericDefault);
            }
            gp.Flatten(new Matrix(), 0.2f);
            PointF[] rotFont = RWM_Polygon_Lib.rotatePolygon(gp.PathPoints, new PointF(0, 0), RWM_Polygon_Lib.ConvertDegreesToRadians(fRotation));

            // wrap ship
            if (pPosition.Y > picDisplayArea.Height / 2) pPosition.Y = -(picDisplayArea.Height / 2);
            if (pPosition.X > picDisplayArea.Width / 2) pPosition.X = -(picDisplayArea.Width / 2);
            if (pPosition.Y < -(picDisplayArea.Height / 2)) pPosition.Y = (picDisplayArea.Height / 2);
            if (pPosition.X < -(picDisplayArea.Width / 2)) pPosition.X = (picDisplayArea.Width / 2);

            // draw Y and thrust fire
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform((float)((picDisplayArea.Width / 2) + pPosition.X), (float)((picDisplayArea.Height / 2) + pPosition.Y));
                g.DrawPolygon(Pens.Black, rotFont);

                // thrust
                if (fThrust > 0)
                {
                    // Create points that define pulse.
                    int iLenght = -15;
                    PointF point1;
                    PointF point2;

                    point1 = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(fRotation + 90), -5);
                    point2 = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(fRotation + 90), iLenght);

                    Pen ThrustPen = new Pen(Brushes.Gold);
                    ThrustPen.Width = 8;

                    // draw thrust
                    g.DrawLine(ThrustPen, point1, point2);
                    ThrustPen.Dispose();
                }
            }

            // draw phaser pulses
            for (int i = 0; i < phaser.Length; i++)
            {
                if (phaser[i].bEnabled)
                {
                    // Create points that define pulse.
                    // todo wrap points around screen
                    int iLenght = 10;
                    pVelocity = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(phaser[i].fMomentumAngle + 90), iLenght);
                    pVelocity.X = pVelocity.X *= (phaser[i].fMomentumVelocity / 10);
                    pVelocity.Y = pVelocity.Y *= (phaser[i].fMomentumVelocity / 10);

                    phaser[i].pCenterPosition.X += pVelocity.X;
                    phaser[i].pCenterPosition.Y += pVelocity.Y;

                    // TODO 
                    // lenght  (phaser[phaserIndex].pStartPosition -> phaser[i].pCenterPosition) > (screen diagonal * ratio)
                    // include screen wrap in distance
                    phaser[i].Distance += iLenght;
                    if (phaser[i].Distance > picDisplayArea.Width * 2)
                    {
                        phaser[i].bEnabled = false;
                        phaser[i].Distance = 0;
                    }

                    // wrap phaser pulses
                    if (phaser[i].pCenterPosition.Y > picDisplayArea.Height / 2) phaser[i].pCenterPosition.Y = -(picDisplayArea.Height / 2);
                    if (phaser[i].pCenterPosition.X > picDisplayArea.Width / 2) phaser[i].pCenterPosition.X = -(picDisplayArea.Width / 2);
                    if (phaser[i].pCenterPosition.Y < -(picDisplayArea.Height / 2)) phaser[i].pCenterPosition.Y = (picDisplayArea.Height / 2);
                    if (phaser[i].pCenterPosition.X < -(picDisplayArea.Width / 2)) phaser[i].pCenterPosition.X = (picDisplayArea.Width / 2);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.TranslateTransform((float)((picDisplayArea.Width / 2)), (float)((picDisplayArea.Height / 2)));
                        g.DrawEllipse(Pens.Black, phaser[i].pCenterPosition.X, phaser[i].pCenterPosition.Y, 2f, 2f);
                    }
                }
            }

            lPaintTime = _st.ElapsedMilliseconds;
            picDisplayArea.Image = bmp;
            gp.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ////    if (e.KeyCode == Keys.Left)
            ////    {
            ////        fRotation -= 3f;
            ////        if (fRotation < -360) fRotation = 0;
            ////    }

            ////    if (e.KeyCode == Keys.Right)
            ////    {
            ////        fRotation += 3f;
            ////        if (fRotation > 360) fRotation = 0;
            ////    }

            ////    if (e.KeyCode == Keys.Up) fThrust = 1f;
            ////    else if (e.KeyCode == Keys.Down) fThrust = -1f;
            ////    else fThrust = -0f;

            ////    if (e.KeyCode == Keys.Space)
            ////    {
            ////        phaserIndex++;
            ////        if (phaserIndex >= phaser.Length) phaserIndex = 0;
            ////        phaser[phaserIndex].fMomentumAngle = fRotation;
            ////        phaser[phaserIndex].fMomentumVelocity = fVelocity + 6;
            ////        phaser[phaserIndex].pCenterPosition = pPosition;
            ////        phaser[phaserIndex].bEnabled = true;

            ////        phaser[phaserIndex].Beep();
            ////    }

            if (e.KeyCode == Keys.Left)
            {
                KeyLFT = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                KeyRT = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                KeyUP = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                KeyDWN = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                KeySpc = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                KeyLFT = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                KeyRT = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                KeyUP = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                KeyDWN = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                KeySpc = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // timer resolution
            timerTick++;
            if (timerTick > tickResolution) timerTick = 0;

            // FORWARD ENGINES trust
            if (fThrust > 0)
            {
                fThrust++;
                fVelocity++;
            }

            // Reverse ENGINES brake thrusters
            if (fThrust < 0)
            {
                fThrust--;
                fVelocity--;
            }

            if (fVelocity < 0) fVelocity = 0;
            if (Math.Abs(fThrust) > (tickResolution / 2)) fThrust = 0;

            if (KeyLFT)
            {
                fRotation -= 3f;
                if (fRotation < -360) fRotation = 0;
            }

            if (KeyRT)
            {
                fRotation += 3f;
                if (fRotation > 360) fRotation = 0;
            }

            if (KeyUP) fThrust = 1f;
            else if (KeyDWN) fThrust = -1f;
            else
            {
                fThrust = -0f;
                fVelocity -= 0.1f;
            }

            if (KeySpc)
            {
                KeySpc = false;
                phaserIndex++;
                if (phaserIndex >= phaser.Length) phaserIndex = 0;
                phaser[phaserIndex].fMomentumAngle = fRotation;
                phaser[phaserIndex].fMomentumVelocity = fVelocity + 6;
                phaser[phaserIndex].pCenterPosition = pPosition;
                phaser[phaserIndex].pStartPosition = pPosition;

                phaser[phaserIndex].bEnabled = true;

                phaser[phaserIndex].Beep();
            }

            //display
            lblThrust.Text = fThrust.ToString();
            lblRotate.Text = fRotation.ToString();
            lblVelocity.Text = fVelocity.ToString();
            lblTime.Text = lPaintTime.ToString();

            //refresh the screen
            this.Invalidate();
            this.Refresh();
        }

        // Polygon functions
        // These don't work perfectly
        // TODO error checking, type sync all should be float or double
        // ANGLE IN RADIANS

        ////public PointF[] rotatePolygon(PointF[] polygon, PointF centroid, double angle)
        ////{
        ////    for (int i = 0; i < polygon.Length; i++)
        ////    {
        ////        polygon[i] = CMS_Polygon_Lib.rotatePoint(polygon[i], centroid, angle);
        ////    }

        ////    return polygon;
        ////}

        ////public PointF rotatePoint(PointF point, PointF centroid, double angle)
        ////{
        ////    double x = centroid.X + ((point.X - centroid.X) * Math.Cos(angle) - (point.Y - centroid.Y) * Math.Sin(angle));

        ////    double y = centroid.Y + ((point.X - centroid.X) * Math.Sin(angle) + (point.Y - centroid.Y) * Math.Cos(angle));

        ////    return new PointF((float)x, (float)y);
        ////}

        ////public PointF[] OffsetPolygon(PointF[] polygon, PointF Start)
        ////{
        ////    for (int i = 0; i < polygon.Length; i++)
        ////    {
        ////        polygon[i] = new PointF(polygon[i].X + Start.X, polygon[i].Y + Start.Y);
        ////    }

        ////    return polygon;
        ////}

        ////public double ConvertDegreesToRadians(double angleDegrees)
        ////{
        ////    double radians = (Math.PI / 180) * angleDegrees;
        ////    return (radians);
        ////}

        ////public static double ConvertRadiansToDegrees(double angleRadians)
        ////{
        ////    double degrees = (180 / Math.PI) * angleRadians;
        ////    return (degrees);
        ////}

        //private PointF EndPoint(double angle, double Length)
        //{

        //    double x1 = 0;
        //    double y1 = 0;
        //    double x2 = x1 + (Math.Cos(angle) * Length);
        //    double y2 = y1 + (Math.Sin(angle) * Length);

        //    float intX2 = Convert.ToInt32(x2);
        //    float intY2 = Convert.ToInt32(y2);

        //    return new PointF(intX2, intY2);

        //}

    } // class

}//namespace
