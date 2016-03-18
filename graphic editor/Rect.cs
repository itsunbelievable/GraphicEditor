using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace graphic_editor
{
    [XmlType("Rect")]
    public class Rect : UserRect
    {
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black, 3),Rect );

            if (IsSelected)
            {
                foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
                {
                    g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
                }
            }
        }

        public override bool Contains(Point p)
        {
            if (Rect.Contains(p))
            {
                IsSelected = true;
                return true;
            }
            return false;
        }
    }
}
