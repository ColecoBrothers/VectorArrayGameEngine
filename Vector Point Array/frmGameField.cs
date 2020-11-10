using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows.Input;

namespace Vector_Point_Array
{
    public partial class frmGameField : Form
    {
        // timer vars
        const int tickResolution = 2;
        long lPaintTime = 0;            // paint time in milliseconds -> how long to paint the frame to the Screen
        int timerTick = 0;

        // USER INPUT
        // Keyboard flags
        // use winuser.h win32 api GetAsyncKeyState
        // or System.Windows.Input.GetKeyStates(Key) 
        // UPDATE timer loop key state does not work, Key events are better
        bool _keyUP = false;
        bool _keyDWN = false;
        bool _keyLFT = false;
        bool _keyRT = false;
        bool _keySpc = false;

        //ship vars
        Ship _ship = new Ship();

        // trust flag vars
        float fThrust = 0;

        //phaser vars
        int phaserIndex = 0;
        Pulse[] phaser = new Pulse[4];

        // rock vars
        Rock[] SpaceRocks;

        Shapes _shapes = new Shapes();

        //Scoring variabales
        int _scorePlayerOne = 0;   //large += 20; medium += 50; small += 100 ; saucerLarge += 200; saucerSmall += 1000;
        int _scorePlayerTwo = 0;
        
        int _livesPlayerOne = 5;
        int _livesPlayerTwo = 3;

 
        public frmGameField()
        {
            InitializeComponent();

            #region init phaser

            for (int i = 0; i < phaser.Length; i++)
            {
                Pulse tmpPhaser = new Pulse();
                tmpPhaser.bEnabled = false;
                tmpPhaser.fMomentumVelocity = 0;
                tmpPhaser.fMomentumAngle = 0;
                tmpPhaser.fScale = 1;
                phaser[i] = tmpPhaser;
            }

            #endregion init phaser

            // vector shape class
            // contains all base vecotro shapes
            

            // define the Ship Shape
            _ship.SetShape(_shapes._ship);
            _ship.SetShape(RWM_Polygon_Lib.ScalePolygon(_ship.Shape, 2.5f)); // TODO make ship scale adjutsable setting

            #region init space rocks

            SpaceRocks = new Rock[Properties.Settings.Default.MaxRocks * 4];
            Random rnd = new Random();

            for (int i = 0; i < SpaceRocks.Length; i++)
            {
                SpaceRocks[i] = new Rock();
                SpaceRocks[i].fMomentumAngle = rnd.Next(-360, 360) + 1;
                SpaceRocks[i].fMomentumVelocity = rnd.Next(0, i * 2) + 1;
                SpaceRocks[i].fRotationAngle = rnd.Next(-5, 5) + 1;

                int posx = rnd.Next(1, picDisplayArea.Width);  // creates a number between 1 and 12
                int posy = rnd.Next(1, picDisplayArea.Height);  // creates a number between 1 and 12

                SpaceRocks[i].pCenterPosition.X = posx;
                SpaceRocks[i].pCenterPosition.Y = posy;
                SpaceRocks[i].fScale = 1; // rnd.Next(3, 7); // set max scale factor as a property setting

                int iRock = rnd.Next(1, 5);
                if (iRock == 1) SpaceRocks[i].SetShape(_shapes._rock1);
                else if (iRock == 2) SpaceRocks[i].SetShape(_shapes._rock2);
                else if (iRock == 3) SpaceRocks[i].SetShape(_shapes._rock3);
                else if (iRock == 4) SpaceRocks[i].SetShape(_shapes._rock4);
                else SpaceRocks[i].SetShape(_shapes._rock5);

                SpaceRocks[i].Shape = RWM_Polygon_Lib.ScalePolygon(SpaceRocks[i].Shape, rnd.Next(6, 10)); // TODO (SM/MD/LG) scale or MIn/max scale factor as a property setting


                if (i <= Properties.Settings.Default.MaxRocks)
                {
                    SpaceRocks[i].bEnabled = true;
                }
                else
                {
                    SpaceRocks[i].bEnabled = false ;
                }

            }

            #endregion init space rocks
        }

        private void frmGameField_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Stopwatch _st = new System.Diagnostics.Stopwatch();
            _st.Start();

            Bitmap bmp = new Bitmap(picDisplayArea.Width, picDisplayArea.Height);
            PointF[] rotFont;
            PointF pVelocity = new PointF(0, 0);

            #region Space rocks

            PointF pMomentumVelocity = new PointF(0, 0);

            for (int i = 0; i < SpaceRocks.Length; i++)
            {
                if (SpaceRocks[i].bEnabled)
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

                        g.TranslateTransform((float)((picDisplayArea.Width / 2) + SpaceRocks[i].pCenterPosition.X), (float)((picDisplayArea.Height / 2) + SpaceRocks[i].pCenterPosition.Y));

                        // surface color
                        //g.FillPolygon(Pens.Crimson.Brush, rotFont);
                        g.FillPolygon(Pens.DarkGray.Brush, rotFont);

                        // outline
                        g.DrawPolygon(Pens.Black, rotFont);

                        //bounds (kill box)
                        Rectangle tmprect = SpaceRocks[i].ShapeBounds();
                        g.DrawRectangle(Pens.Aqua, tmprect);
                    
                    }
                }
            }

            #endregion Space rocks

            #region Ship flying

            if (_ship.fMomentumVelocity > 0)
            {
                // Create points that define pulse.
                int iLenght = 10;
                pVelocity = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(_ship.fMomentumAngle + 90), iLenght);
                pVelocity.X = pVelocity.X *= (_ship.fMomentumVelocity / 10);
                pVelocity.Y = pVelocity.Y *= (_ship.fMomentumVelocity / 10);
            }
            _ship.pCenterPosition.X += pVelocity.X;
            _ship.pCenterPosition.Y += pVelocity.Y;

            //shipshape
            rotFont = new PointF[_ship.iShapeLength];
            _ship.Shape.CopyTo(rotFont, 0);
            rotFont = RWM_Polygon_Lib.rotatePolygon(rotFont, new PointF(0, 0), RWM_Polygon_Lib.ConvertDegreesToRadians(_ship.fMomentumAngle));

            // wrap ship
            if (_ship.pCenterPosition.Y > picDisplayArea.Height / 2) _ship.pCenterPosition.Y = -(picDisplayArea.Height / 2);
            if (_ship.pCenterPosition.X > picDisplayArea.Width / 2) _ship.pCenterPosition.X = -(picDisplayArea.Width / 2);
            if (_ship.pCenterPosition.Y < -(picDisplayArea.Height / 2)) _ship.pCenterPosition.Y = (picDisplayArea.Height / 2);
            if (_ship.pCenterPosition.X < -(picDisplayArea.Width / 2)) _ship.pCenterPosition.X = (picDisplayArea.Width / 2);

            // draw ship and thrust fire
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform((float)((picDisplayArea.Width / 2) + _ship.pCenterPosition.X), (float)((picDisplayArea.Height / 2) + _ship.pCenterPosition.Y));

                g.FillPolygon(Pens.WhiteSmoke.Brush, rotFont);
                g.DrawPolygon(Pens.Black, rotFont);


                // Draw Thrust
                if (fThrust > 0)
                {
                    // Create points that define thrust image.
                    int iLenght = -15;
                    PointF point1;
                    PointF point2;

                    point1 = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(_ship.fMomentumAngle + 90), -8);
                    point2 = RWM_Polygon_Lib.EndPoint(RWM_Polygon_Lib.ConvertDegreesToRadians(_ship.fMomentumAngle + 90), iLenght);

                    Pen ThrustPen = new Pen(Brushes.Gold);
                    ThrustPen.Width = 8;

                    // draw thrust
                    g.DrawLine(ThrustPen, point1, point2);
                    ThrustPen.Dispose();
                }
            }

            #endregion Ship flying

            #region Ship phasers
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

                    // phaser screen wrap in distance screen width * ratio
                    phaser[i].Distance += iLenght;
                    if (phaser[i].Distance > picDisplayArea.Width * 1)   // TODO Make distance raton adjutstable setting
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

            for (int i = 0; i < phaser.Length; i++)
            {
                if (phaser[i].bEnabled)
                {

                    Point tmpPhaserPoint = new Point((int)phaser[i].pCenterPosition.X, (int)phaser[i].pCenterPosition.Y); // screen position of phaser pulse

                    // check kill box
                    for (int iRock = 0; iRock < SpaceRocks.Length; iRock++)
                    {
                        if (SpaceRocks[iRock].bEnabled)
                        {
                            Point tmpPoint = new Point(tmpPhaserPoint.X - (int)SpaceRocks[iRock].pCenterPosition.X, tmpPhaserPoint.Y - (int)SpaceRocks[iRock].pCenterPosition.Y);

                            if (SpaceRocks[iRock].fRectBounds.Contains(tmpPoint))
                            {

                                if (SpaceRocks[iRock].fScale == 1) _scorePlayerOne += 20;
                                if (SpaceRocks[iRock].fScale == 2) _scorePlayerOne += 50;
                                if (SpaceRocks[iRock].fScale >= 3)
                                {
                                    _scorePlayerOne += 100;
                                    SpaceRocks[iRock].bEnabled = false;
                                }
                                else
                                {
                                    int iNextRock = 0;
                                    for (iNextRock = 0; iNextRock < SpaceRocks.Length; iNextRock++)
                                    {
                                        if (SpaceRocks[iNextRock].bEnabled == false) break;
                                    }

                                    SpaceRocks[iNextRock].pCenterPosition = SpaceRocks[iRock].pCenterPosition;
                                    SpaceRocks[iNextRock].SetShape(RWM_Polygon_Lib.ScalePolygon(SpaceRocks[iRock].Shape, 0.5f));
                                    SpaceRocks[iNextRock].fRotationAngle = SpaceRocks[iRock].fRotationAngle;
                                    SpaceRocks[iNextRock].fMomentumAngle = phaser[i].fMomentumAngle + 45;
                                    SpaceRocks[iNextRock].fMomentumVelocity = phaser[i].fMomentumVelocity * 0.8f;
                                    SpaceRocks[iNextRock].bEnabled = true;
                                    SpaceRocks[iNextRock].fScale = SpaceRocks[iRock].fScale + 1;

                                    SpaceRocks[iRock].fScale++;
                                    SpaceRocks[iRock].SetShape(RWM_Polygon_Lib.ScalePolygon(SpaceRocks[iRock].Shape, 1));
                                    SpaceRocks[iRock].fRotationAngle = SpaceRocks[iRock].fRotationAngle;
                                    SpaceRocks[iRock].fMomentumAngle = phaser[i].fMomentumAngle - 45;
                                    SpaceRocks[iRock].fMomentumVelocity = phaser[i].fMomentumVelocity * 2f;
                                    SpaceRocks[iRock].bEnabled = true;
                                }

                                phaser[i].bEnabled = false;

                            }

                        }
                    }
                }
            }

            #endregion Ship phasers

            #region Payer Informaton

            // draw score
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                
                // Measure string.
                // TODO move outside of active paint loop
                Font ScoreFont = new Font("Arial", 12f);
                string measureString = "00000000";
                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(measureString, ScoreFont);

                // Player 1 score
                // TODO get string length and define start position as percentage of Boarder (x, Y)
                // TODO get mid-pint of score as start potion of LIVES
                // TODO get height of score as top of Lives
                g.DrawString(_scorePlayerOne.ToString("00000000"), ScoreFont, Pens.Black.Brush, new PointF(40, 20));

                PointF[] pLifeShips = new PointF[_shapes._ship.Length];
                _shapes._ship.CopyTo(pLifeShips, 0);

                PointF startLives = new PointF(40 + (stringSize.Width / 2), 20 + stringSize.Height);  // 83,40
                pLifeShips = RWM_Polygon_Lib.OffsetPolygon(pLifeShips, startLives);

                for (int i = 0; i < _livesPlayerOne; i++)
                {
                    g.DrawPolygon(Pens.Black, pLifeShips);
                    
                    startLives.X = 8;  // TODO get Width fomm bounds
                    startLives.Y = 0;
                    pLifeShips = RWM_Polygon_Lib.OffsetPolygon(pLifeShips, startLives);
                }

                //player 2 score
                

                // Draw player two score 
                // TODO as percentage right justified of screen width
                g.DrawString(_scorePlayerTwo.ToString("00000000"), ScoreFont, Pens.Black.Brush, new PointF((picDisplayArea.Width - 40 - stringSize.Width), 20));
               
                ScoreFont.Dispose();
            }


            #endregion Payer Informaton

            lPaintTime = _st.ElapsedMilliseconds;
            picDisplayArea.Image = bmp;
           
        }
   
        private void frmGameField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _keyLFT = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                _keyRT = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                _keyUP = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                _keyDWN = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                _keySpc = true;
            }
        }

        private void frmGameField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _keyLFT = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                _keyRT = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                _keyUP = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                _keyDWN = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                _keySpc = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // timer tick => counter resolution
            timerTick++;
            if (timerTick > tickResolution) timerTick = 0;

            if (_keyLFT)
            {
                _ship.fMomentumAngle -= 10f;
            }

            if (_keyRT)
            {
                _ship.fMomentumAngle += 10f;
            }

            if (_keyUP) fThrust = 1f;        // forward thrust
            else if (_keyDWN) fThrust = -1f; // reverse thrust to stop 
            else fThrust = 0f;

            // FORWARD ENGINES trust
            if (fThrust > 0)
            {
                _ship.fMomentumVelocity++;
            }

            // Reverse ENGINES brake thrusters
            if (fThrust < 0)
            {
                _ship.fMomentumVelocity--;
            }

            // no thrust = space drag deleration
            if (fThrust == 0)
            {
                _ship.fMomentumVelocity -= 0.2f;  // TODO make deceleration (drag) a config setting
            }

            if (_ship.fMomentumVelocity < 0) _ship.fMomentumVelocity = 0;

            //if (timerTick == 0)
            //if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Space))
            // ADD PRESENTATION CORE AND WINDOWS BASE REFERENCE
            // THIS IS MUCH FASSTER BUT NOT EVENT DRIVEN 
            // EVENT OVERHEAD IS MUCH BETTER USER RESPONCE
            // THI SIS TIMER BAQSED AND ASYNC TOTHE USER INPUT (NOT DESIREABLE)

            if (_keySpc)
            {
                _keySpc = false;

                // only 4 shots at a time
                // loop searching an array is slow
                for (int i = 0; i < phaser.Length; i++)
                {
                    if (!phaser[i].bEnabled)
                    {
                        phaserIndex = i;
                        break;
                    }
                }

                if (!phaser[phaserIndex].bEnabled)
                {
                    phaser[phaserIndex].fMomentumAngle = _ship.fMomentumAngle;
                    phaser[phaserIndex].fMomentumVelocity = _ship.fMomentumVelocity + 6;  // TODO make phaser velocity delta adjustable config setting
                    phaser[phaserIndex].pCenterPosition = _ship.pCenterPosition;
                    phaser[phaserIndex].pStartPosition = _ship.pCenterPosition;
                    phaser[phaserIndex].bEnabled = true;

                    phaser[phaserIndex].Beep();
                }
            }

            //display data
            lblThrust.Text = fThrust.ToString();
            lblRotate.Text = _ship.fMomentumAngle.ToString();
            lblVelocity.Text = _ship.fMomentumVelocity.ToString();
            lblTime.Text = lPaintTime.ToString();

            //refresh the screen
            this.Invalidate();
            this.Refresh();
        }

    } // class
} // namespace
