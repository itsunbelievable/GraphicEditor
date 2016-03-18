using System;
using System.Drawing;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace graphic_editor
{
    public abstract class UserRect
    {
        protected Rectangle Rect;
        [XmlIgnore]
        public bool IsSelected { get; set; }
        //node for resize
        private int NodeSize =10;

        [XmlElement("X")]
        public int X
        {
            get { return Rect.X; }
            set { Rect.X = value; }
        }

        [XmlElement("Y")]
        public int Y
        {
            get { return Rect.Y; }
            set { Rect.Y = value; }
        }

        [XmlElement("Height")]
        public int Height
        {
            get { return Rect.Height; }
            set { Rect.Height = value; }
        }

        [XmlElement("Width")]
        public int Width
        {
            get { return Rect.Width; }
            set { Rect.Width = value; }
        }

        public abstract void Draw(Graphics g);

        protected UserRect()
        {
           Rect = new Rectangle(0,0,100,100);
        }

        public abstract bool Contains(Point p);

        public PosSizableRect GetNodeSelectable(Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;
                }
            }
            return PosSizableRect.None;
        }

        private Rectangle GetSizableRect(int x, int y)
        {
            return new Rectangle(x - NodeSize / 2, y - NodeSize / 2, NodeSize, NodeSize);
        }

        protected Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                    case PosSizableRect.Up:
                    return GetSizableRect(Rect.X + Rect.Width/2, Rect.Y);

                    case PosSizableRect.Left:
                    return GetSizableRect(Rect.X, Rect.Y + Rect.Height/2);

                    case PosSizableRect.Right:
                    return GetSizableRect(Rect.X + Rect.Width, Rect.Y + Rect.Height / 2);

                    case PosSizableRect.Bottom:
                    return GetSizableRect(Rect.X + Rect.Width/2, Rect.Y + Rect.Height);

                default:
                    return new Rectangle();
            }
        }
    }
}
