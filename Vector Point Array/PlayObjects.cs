using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Vector_Point_Array
{
    //https://arcadeblogger.com/2018/10/24/atari-asteroids-creating-a-vector-arcade-classic/

    public class LetterY
    {
        public PointF pCenterPosition = new PointF(0, 0);

        private float _fMomentumAngle = 0;
        private float _fMomentumVelocity = 0;

        private PointF[] _shape;

        public LetterY()
        {
            GraphicsPath gp = new GraphicsPath();

            // Y 
            using (Font f = new Font("Tahoma", 24f))
            {
                gp.AddString("Y", f.FontFamily, 0, 24f, new Point(-11, -11), StringFormat.GenericDefault);
            }

            gp.Flatten(new Matrix(), 0.2f);

            _shape = new PointF[gp.PathPoints.Length];

            gp.PathPoints.CopyTo(_shape, 0);

            gp.Dispose();

        }

        // properties

        public PointF[] Shape
        {
            get
            {
                return this._shape;
            }
            set
            {
                this._shape = value;
            }
        }

        public float fMomentumAngle
        {
            get
            {
                return this._fMomentumAngle;
            }
            set
            {
                if (value > 360) value = 0;
                if (value < -360) value = 0;
                this._fMomentumAngle = value;
            }
        }

        public float fMomentumVelocity
        {
            get
            {
                return this._fMomentumVelocity;
            }
            set
            {
                if (value < 0) value = 0;
                this._fMomentumVelocity = value;
            }
        }

    }

    public class Ship
    {
        public PointF pCenterPosition = new PointF(0, 0);

        private float _fMomentumAngle = 0;
        private float _fMomentumVelocity = 0;
        private int _shapeSize = 0;
        private PointF[] _shape;

        public Ship()
        {
            GraphicsPath gp = new GraphicsPath();

            // Y 
            using (Font f = new Font("Tahoma", 24f))
            {
                gp.AddString("Y", f.FontFamily, 0, 24f, new Point(-11, -11), StringFormat.GenericDefault);
            }
            gp.Flatten(new Matrix(), 0.2f);

            _shape = new PointF[gp.PathPoints.Length];

            gp.PathPoints.CopyTo(_shape, 0);
            gp.Dispose();

        }

        // properties

        public PointF[] Shape
        {
            get
            {
                return this._shape;
            }
            set
            {
                this._shape = value;
            }
        }

        public float fMomentumAngle
        {
            get
            {
                return this._fMomentumAngle;
            }
            set
            {
                if (value > 360) value = 0;
                if (value < -360) value = 0;
                this._fMomentumAngle = value;
            }
        }

        public float fMomentumVelocity
        {
            get
            {
                return this._fMomentumVelocity;
            }
            set
            {
                if (value < 0) value = 0;
                this._fMomentumVelocity = value;
            }
        }

        public int iShapeLength
        {
            get
            {
                _shapeSize = _shape.Length;
                return this._shapeSize;
            }
            set
            {
                this._shapeSize = value;
                Array.Resize(ref _shape, _shapeSize);
            }
        }

        public bool SetShape(PointF[] NewShape)
        {
            bool retValue = true;

            this.iShapeLength = NewShape.Length;
            NewShape.CopyTo(this.Shape, 0);

            return retValue;
        }
 
    }

    public class Pulse
    {
        public PointF pCenterPosition = new PointF(0, 0);
        public PointF pStartPosition = new PointF(0, 0);
        public int Distance = 0;

        private float _fMomentumAngle = 0;
        private float _fMomentumVelocity = 0;
        private float _fScale = 1;
        private bool _enabled = false;

        // properties
        public bool bEnabled
        {
            get
            {
                return this._enabled;
            }
            set
            {

                this._enabled = value;
            }
        }

        public float fScale
        {
            get
            {
                return this._fScale;
            }
            set
            {

                this._fScale = value;
            }
        }

        public float fMomentumAngle
        {
            get
            {
                return this._fMomentumAngle;
            }
            set
            {
                if (value > 360) value = 0;
                if (value < -360) value = 0;
                this._fMomentumAngle = value;
            }
        }

        public float fMomentumVelocity
        {
            get
            {
                return this._fMomentumVelocity;
            }
            set
            {
                if (value < 0) value = 0;
                this._fMomentumVelocity = value;
            }
        }

        public void Beep()
        {
            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                Console.Beep(440, 100);
                //Console.Beep(1000, 50);
                //System.Media.SystemSounds.Asterisk.Play(); 
            }).Start();
        }
    }

    public class Rock
    {
        public PointF[] _shape = new PointF[] 
        { 
            new PointF { X = 5, Y = 15 }, 
            new PointF { X = 11, Y = 10 }, 
            new PointF { X = 12, Y = 1 }, 
            new PointF { X = 10, Y = -5 },
            new PointF { X = 5, Y = -10 },
            new PointF { X = 1, Y = -12 }, 
            new PointF { X = -7, Y = -5 }, 
            new PointF { X = -8, Y = 2 },
            new PointF { X = -9, Y = 7 },
            new PointF { X = 0, Y = 15 }
        };

        public PointF pCenterPosition = new PointF(0, 0);
        private float _fRotationAngle = 0;
        private float _fMomentumAngle = 0;
        private float _fMomentumVelocity = 0;
        private float _fScale = 1;
        private Rectangle _fRectBounds;

        private int _shapeSize = 0;

        private bool _enabled = false;

        // properties
        public bool bEnabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        public int iShapeLength
        {
            get
            {
                _shapeSize = _shape.Length;
                return this._shapeSize;
            }
            set
            {
                this._shapeSize = value;
                Array.Resize(ref _shape, _shapeSize);
            }
        }

        public float fScale
        {
            get
            {
                return this._fScale;
            }
            set
            {
                if (value <= 0) value = 0f;
                this._fScale = value;
            }
        }

        public float fRotationAngle
        {
            get
            {
                return this._fRotationAngle;
            }
            set
            {
                if (value > 360) value = (value % 360);
                if (value < -360) value = (value % 360);
                this._fRotationAngle = value;
            }
        }

        public float fMomentumAngle
        {
            get
            {
                return this._fMomentumAngle;
            }
            set
            {
                if (value > 360) value = 0;
                if (value < -360) value = 0;
                this._fMomentumAngle = value;
            }
        }

        public float fMomentumVelocity
        {
            get
            {
                return this._fMomentumVelocity;
            }
            set
            {
                if (value < 0) value = 0;
                this._fMomentumVelocity = value;
            }
        }

        public Rectangle fRectBounds
        {
            get
            {
                return this._fRectBounds;
            }
            //set
            //{
            //    this._fRectBounds = value;
            //}
        }

        public PointF[] Shape
        {
            get
            {
                return this._shape;
            }
            set
            {
                this._shape = value;
            }
        }

        public Rectangle ShapeBounds()
        {
            int minX = 65535;
            int maxX = -65535;

            int minY = 65535;
            int maxY = -65535;

            for (int i = 0; i < _shape.Length; i++)
            {
                if (_shape[i].X < minX) minX = (int)_shape[i].X;
                if (_shape[i].X > maxX) maxX = (int)_shape[i].X;
                if (_shape[i].Y < minY) minY = (int)_shape[i].Y;
                if (_shape[i].Y > maxY) maxY = (int)_shape[i].Y;
            }

            _fRectBounds = new Rectangle((int)(minX), (int)(minY), (int)((maxX - minX)), (int)((maxY - minY)));

            return _fRectBounds;
        }

        // methods

        public bool SetShape(PointF[] NewShape)
        {
            bool retValue = true;

            this.iShapeLength = NewShape.Length;
            NewShape.CopyTo(this.Shape, 0);

            return retValue;
        }
    }

    public class Shapes
    {
        // random rock shape 
        public PointF[] _RockTest = new PointF[] 
        { 
            new PointF { X = 5, Y = 15 }, 
            new PointF { X = 11, Y = 10 }, 
            new PointF { X = 12, Y = 1 }, 
            new PointF { X = 10, Y = -5 },
            new PointF { X = 5, Y = -10 },
            new PointF { X = 1, Y = -12 }, 
            new PointF { X = -7, Y = -5 }, 
            new PointF { X = -8, Y = 2 },
            new PointF { X = -9, Y = 7 },
            new PointF { X = 0, Y = 15 }
        };

        // origional as drawn
        public PointF[] _realShip = new PointF[] 
        { 
            new PointF { X = 56, Y = 0 }, 
            new PointF { X = -40, Y = 32 }, 
            new PointF { X = -24, Y = 16 }, 
            new PointF { X = -24, Y = -16 },
            new PointF { X = -40, Y = -32 },
            new PointF { X = 56, Y = 0 }
        };

        // scaled like the rocks
        public PointF[] _ship = new PointF[] 
        { 
            new PointF { X = -3, Y = -4 }, 
            new PointF { X = -1, Y = -3 }, 
            new PointF { X = 1, Y = -3 }, 
            new PointF { X = 3, Y = -4 },
            new PointF { X = 0, Y = 4 }
        };

        
        public PointF[] _saucer = new PointF[] 
        { 
            new PointF { X = 5, Y = -1 }, 
            new PointF { X = 2, Y = 1 }, 
            new PointF { X = 1, Y = 3 }, 
            new PointF { X = -1, Y = 3 },
            new PointF { X = -2, Y = 1 },
            new PointF { X = -5, Y = -1 },
            new PointF { X = -2, Y = -3 },
            new PointF { X = 2, Y = -3 },
            new PointF { X = 5, Y = -1 },
            new PointF { X = -5, Y = -1 }
        };

        // bonus round easer ed Pizza hut hat saucer
        public PointF[] _pizzaHat = new PointF[] 
        { 
            new PointF { X = 5, Y = -1 }, 
            new PointF { X = 2, Y = 1 }, 
            new PointF { X = 1, Y = 3 }, 
            new PointF { X = -1, Y = 3 },
            new PointF { X = -2, Y = 1 },
            new PointF { X = -5, Y = 0 },
            new PointF { X = 5, Y = -1 },
            new PointF { X = -5, Y = -1 },
            new PointF { X = -2, Y = -3 },
            new PointF { X = 2, Y = -3 },
            new PointF { X = 5, Y = -1 }
            };

        public PointF[] _rock5 = new PointF[] 
        { 
            new PointF { X = 4, Y = 2 }, 
            new PointF { X = 2, Y = 4 }, 
            new PointF { X = -2, Y = 4 }, 
            new PointF { X = -4, Y = 2 },
            new PointF { X = -4, Y = -2 },
            new PointF { X = -2, Y = -4 },
            new PointF { X = 2, Y = -4 },
            new PointF { X = 4, Y = -2 }
        };

        public PointF[] _rock4 = new PointF[] 
        { 
            new PointF { X = 1, Y = 0 }, 
            new PointF { X = 4, Y = 1 }, 
            new PointF { X = 4, Y = 2 }, 
            new PointF { X = 0, Y = 4 },
            new PointF { X = -2, Y = 4 },
            new PointF { X = -1, Y = 2 },
            new PointF { X = -4, Y = 2 },
            new PointF { X = -4, Y = -1 },
            new PointF { X = -2, Y = -4 },
            new PointF { X = 1, Y = -3 },
            new PointF { X = 2, Y = -4 },
            new PointF { X = 4, Y = -2 }
        };

        public PointF[] _rock3 = new PointF[] 
        { 
            new PointF { X = 4, Y = -1 }, 
            new PointF { X = 2, Y = 4 }, 
            new PointF { X = -1, Y = 4 },
            new PointF { X = -4, Y = 1 },
            new PointF { X = -2, Y = 0 },
            new PointF { X = -4, Y = -1 },
            new PointF { X = -4, Y = -1 },
            new PointF { X = -2, Y = -4 },
            new PointF { X = 0, Y = -1 },
            new PointF { X = 0, Y = -4 },
            new PointF { X = 2, Y = -4 }
        };

        public PointF[] _rock2 = new PointF[] 
        { 
            new PointF { X = 2, Y = 1 }, 
            new PointF { X = 4, Y = 2 }, 
            new PointF { X = 2, Y = 4 },
            new PointF { X = 0, Y = 3 },
            new PointF { X = -2, Y = 4 },
            new PointF { X = -4, Y = 2 },
            new PointF { X = -3, Y = 0 },
            new PointF { X = -4, Y = -2 },
            new PointF { X = -2, Y = -4 },
            new PointF { X = -1, Y = -3 },
            new PointF { X = 2, Y = -4 }
        };

        public PointF[] _rock1 = new PointF[] 
        { 
            new PointF { X = 2, Y = 4 }, 
            new PointF { X = 0, Y = 2 }, 
            new PointF { X = -2, Y = 4 },
            new PointF { X = -4, Y = 2 },
            new PointF { X = -4, Y = -2 },
            new PointF { X = 0, Y = -4 },
            new PointF { X = 4, Y = -2 },
            new PointF { X = 2.5f, Y = 0 },
            new PointF { X = 4, Y = 2 }
          
        };

    }

}//namespace

