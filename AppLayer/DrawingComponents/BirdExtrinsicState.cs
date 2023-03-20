using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class BirdExtrinsicState
    {
        [DataMember]
        public string BirdType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        public BirdExtrinsicState Clone()
        {
            return new BirdExtrinsicState()
            {
                BirdType = BirdType,
                Location = Location,
                Size = Size,
                IsSelected = IsSelected
            };
        }
    }
}
