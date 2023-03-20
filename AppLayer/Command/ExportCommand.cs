using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class ExportCommand : Command
    {
        //Trey: Image save to png requirement 7
        private string fileName;
        private Bitmap image;
        internal ExportCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0) 
            {
                fileName = commandParameters[0] as string;
            }
            if (commandParameters.Length > 1)
            {
                image = commandParameters[1] as Bitmap;
            }
        }
        public override bool Execute()
        {
            image.Save(fileName, ImageFormat.Png);
            return true;
        }

        internal override void Redo()
        {
            Execute();
        }

        internal override void Undo()
        {
            // We don't delete a previous file
        }
    }
}
