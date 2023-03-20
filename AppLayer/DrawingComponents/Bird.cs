using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Bird : Element
    {
        public static Pen SelectedPen { get; set; } = new Pen(Color.DarkGray);
        public static Size ToolSize { get; set; } = new Size() { Width = 64, Height = 64};
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);
        public override bool MoveToPoint(Point point)
        {
            Location= point;
            return true;
        }
        public override Point getLocation()
        {
            return Location;
        }
        public override bool SetScale(float scale)
        {
            if (Size == null) return false;
            Size = new Size(new Point((int)(Size.Width * scale), (int)(Size.Height * scale)));
            return true;
        }
    }
}
