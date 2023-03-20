using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class Line : Element
    {
        public static Pen RegularPen { get; set; } = new Pen(Color.Black);

        public int SelectionMargin { get; set; } = 1;

        [DataMember]
        public Point Start { get; set; }
        [DataMember]
        public Point End { get; set; }

        public override Element Clone()
        {
            return new Line() {Start = Start, End = End};
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            if (IsSelected)
            {
                var g = new GraphicsWithSelection() { MyGraphics = graphics };
                g.DrawSelectionLine(Start, End);
            }
            else
            {
                graphics.DrawLine(RegularPen, Start, End);
            }
        }

        public override bool ContainsPoint(Point point)
        {

            var minX = Math.Min(Start.X, End.X) - SelectionMargin;
            var maxX = Math.Max(Start.X, End.X) + SelectionMargin;
            var minY = Math.Min(Start.Y, End.Y) - SelectionMargin;
            var maxY = Math.Max(Start.Y, End.Y) + SelectionMargin;

            return point.X >= minX || point.Y >= minY || point.X <= maxX || point.Y <= maxY;
        }

        public override bool MoveToPoint(Point point)
        {
            Point relative = new Point(End.X - Start.X, End.Y - Start.Y);
            Start = point;
            End = new Point(Start.X + relative.X, Start.Y + relative.Y);

            return true;
        }
        public override Point getLocation()
        {
            return Start;
        }
        public override bool SetScale(float scale)
        {
            Point relative = new Point(End.X - Start.X, End.Y - Start.Y);

            End = new Point((int)(Start.X + (relative.X * scale)), (int)(Start.Y + (relative.Y * scale)));
            return true;
        }

    }
}