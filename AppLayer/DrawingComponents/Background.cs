using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class Background
    {
        public Bitmap map { get; set; }
        [DataMember]
        public byte[] mapBytes { get; set; }

        public void convertMapToBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                map.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                mapBytes = stream.ToArray();
            }
        }
        public void convertBytesToMap()
        {
            if (mapBytes == null) return;
            using (MemoryStream stream = new MemoryStream(mapBytes))
            {
                map = new Bitmap(stream);
            }
        }
    }
}
