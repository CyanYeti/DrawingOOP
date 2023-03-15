using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class ChangeBackgroundCommand : Command
    {
        private Background background;
        internal ChangeBackgroundCommand(params object[] commandParameters) 
        { 
            if (commandParameters.Length>0)
            {
                background = commandParameters[0] as Background;
            }
        }

        public override bool Execute()
        {
            if (TargetDrawing == null) return false;

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
