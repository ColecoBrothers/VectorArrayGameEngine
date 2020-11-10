using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Vector_Point_Array
{
    public partial class Form2 : Form
    {
        // Test Form to show arrays of polygons
        // uses Rock Class to form array
        // Rock Shape is Polygon shape definition
        // Animatin is determined in the paint Funcition
        // its mostly hardcoded constants
        // the first rock in the array reponds to user input like the letter Y on the first form
        // it can be used to determone the best range for constants on a specific system.

        const int tickResolution = 10;
        int timerTick = 0;
        long lPaintTime = 0;
        Rock[] SpaceRocks;
        Rock SpaceRock;

        Point _landmine;
         
        public Form2()
        {
            InitializeComponent();

            #region init space rocks

            SpaceRocks = new Rock[Properties.Settings.Default.MaxRocks];
            Random rnd = new Random();

            Shapes _shapes = new Shapes();

            for (int i = 0; i < SpaceRocks.Length; i++)
            {
                SpaceRocks[i] = new Rock();
                SpaceRocks[i].fMomentumAngle = rnd.Next(-360, 360) + 1;
                SpaceRocks[i].fMomentumVelocity = rnd.Next(0, i*2) + 1;
                SpaceRocks[i].fRotationAngle = rnd.Next(-10, 10) + 1;

                int posx = rnd.Next(1, picDisplayArea.Width);  // creates a number between 1 and 12
                int posy = rnd.Next(1, picDisplayArea.Height);  // creates a number between 1 and 12

                SpaceRocks[i].pCenterPosition.X = posx;
                SpaceRocks[i].pCenterPosition.Y = posy;
                SpaceRocks[i].fScale = 1; // rnd.Next(3, 7); // set max scale factor as a property setting

                SpaceRocks[i].SetShape(_shapes._rock1);

                SpaceRocks[i].Shape = RWM_Polygon_Lib.ScalePolygon(SpaceRocks[i].Shape, rnd.Next(4, 8)); // TODO (SM/MD/LG) scale or MIn/max scale factor as a property setting
            }

            #endregion init space rocks

            SpaceRock = SpaceRocks[0];
            _landmine = new Point(picDisplayArea.Width / 2, picDisplayArea.Height / 2);

        }
  
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Stopwatch _st = new System.Diagnostics.Stopwatch();
            _st.Start();
            
            Bitmap bmp = new Bitmap(picDisplayArea.Width, picDisplayArea.Height);
            PointF pMomentumVelocity = new PointF(0, 0);
            PointF[] rotFont;

            for (int i = 0; i < SpaceRocks.Length; i++)
            {
                if (SpaceRocks[i].fMomentumVelocity > 0)
                {
                    int iLenght = 10;
                    pMomentumVelocity = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(SpaceRocks[i].fMomentumAngle + 90), iLenght);
                    pMomentumVelocity.X = pMomentumVelocity.X *= (SpaceRocks[i].fMomentumVelocity / 100);
                    pMomentumVelocity.Y = pMomentumVelocity.Y *= (SpaceRocks[i].fMomentumVelocity / 100);
                }

                SpaceRocks[i].pCenterPosition.X += pMomentumVelocity.X;
                SpaceRocks[i].pCenterPosition.Y += pMomentumVelocity.Y;

                rotFont = RWM_Polygon_Lib.rotatePolygon(SpaceRocks[i].Shape, new PointF(0, 0), RWM_Polygon_Lib.ConvertDegreesToRadians(SpaceRocks[i].fRotationAngle));

                // wrap screen
                if (SpaceRocks[i].pCenterPosition.Y > picDisplayArea.Height / 2) SpaceRocks[i].pCenterPosition.Y = -(picDisplayArea.Height / 2);
                if (SpaceRocks[i].pCenterPosition.X > picDisplayArea.Width / 2) SpaceRocks[i].pCenterPosition.X = -(picDisplayArea.Width / 2);

                if (SpaceRocks[i].pCenterPosition.Y < -(picDisplayArea.Height / 2)) SpaceRocks[i].pCenterPosition.Y = (picDisplayArea.Height / 2);
                if (SpaceRocks[i].pCenterPosition.X < -(picDisplayArea.Width / 2)) SpaceRocks[i].pCenterPosition.X = (picDisplayArea.Width / 2);

                // draw space rocks
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    
                    g.DrawEllipse(Pens.Red,_landmine.X, _landmine.Y, 5,5);
                    g.TranslateTransform((float)((picDisplayArea.Width / 2) + SpaceRocks[i].pCenterPosition.X), (float)((picDisplayArea.Height / 2) + SpaceRocks[i].pCenterPosition.Y));
                  
                    // surface color
                    //g.FillPolygon(Pens.Crimson.Brush, rotFont);
                    g.FillPolygon(Pens.DarkGray.Brush, rotFont);
                    
                    // outline
                    g.DrawPolygon(Pens.Black, rotFont);
                   
                    //bounds (kill box)
                    Rectangle tmprect = SpaceRocks[i].ShapeBounds();
                    g.DrawRectangle(Pens.Aqua, tmprect);

                    Point tmpPoint = new Point(_landmine.X, _landmine.Y); // screen position of phaser pulse

                    tmpPoint.X -= (picDisplayArea.Width / 2); //+ SpaceRocks[i].pCenterPosition.X);
                    tmpPoint.Y -= (picDisplayArea.Height / 2); //+ SpaceRocks[i].pCenterPosition.Y);
                    tmpPoint.X +=  (int) SpaceRocks[i].pCenterPosition.X;
                    tmpPoint.Y +=  (int) SpaceRocks[i].pCenterPosition.Y;

                    if (tmprect.Contains(tmpPoint))
                    {
                        SpaceRocks[i].fScale -= .10f;
                        SpaceRocks[i].Shape = RWM_Polygon_Lib.ScalePolygon(SpaceRocks[i].Shape, SpaceRocks[i].fScale);
                    }
                }
            }

            lPaintTime = _st.ElapsedMilliseconds;
            picDisplayArea.Image = bmp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.KeyCode == Keys.Left)
                {
                    SpaceRock.fRotationAngle -= 1f;
                }

                if (e.KeyCode == Keys.Right)
                {
                    SpaceRock.fRotationAngle += 1f;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Left)
                {
                    SpaceRock.fMomentumAngle -= 1f;
                }

                if (e.KeyCode == Keys.Right)
                {
                    SpaceRock.fMomentumAngle += 1f;
                }
            }

            if (e.KeyCode == Keys.Up) SpaceRock.fMomentumVelocity += 1f;
            if (e.KeyCode == Keys.Down) SpaceRock.fMomentumVelocity += -1f;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // timer resolution
            timerTick++;
            if (timerTick > tickResolution) timerTick = 0;

            //display
            lblRotationAngle.Text = SpaceRock.fRotationAngle.ToString();
            lblMomentumVelocity.Text = SpaceRock.fMomentumVelocity.ToString();
            lblMomentumAngle.Text = SpaceRock.fMomentumAngle.ToString();
            lblTime.Text = lPaintTime.ToString();
            //refresh the screen
            this.Invalidate();
            this.Refresh();
        }
 
    } // class
}//namespace
