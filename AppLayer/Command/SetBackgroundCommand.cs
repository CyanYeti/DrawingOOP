using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class SetBackgroundCommand : Command
    {
        private Bitmap background;

        internal SetBackgroundCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                background = commandParameters[0] as Bitmap;
            }
        }

        public override bool Execute()
        {
            TargetDrawing.SetBackground(background);
            return true;
        }

        internal override void Redo()
        {
            throw new NotImplementedException();
        }

        internal override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
