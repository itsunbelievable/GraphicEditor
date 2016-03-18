using System;
using System.Drawing;
using System.Xml.Serialization;

namespace graphic_editor
{
    [XmlType("Circle")]
    public class Circle : UserRect
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black,3), Rect);

            if (IsSelected)
            {
                foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
                {
                    g.DrawRectangle(new Pen(Color.Red), GetRect(pos) );
                }
            }
        }

        public override bool Contains(Point p)
        {
            Point center = new Point(Rect.X + Rect.Width/2, Rect.Y + Rect.Height/2);
            Point normalized = new Point(p.X - center.X, p.Y - center.Y);

            double xRadius = (double)Rect.Width/2;
            double yRadius = (double)Rect.Height/2;

            return (normalized.X*normalized.X/(xRadius*xRadius)) +
                   (normalized.Y*normalized.Y/(yRadius*yRadius)) <=1;
        }
    }
}
