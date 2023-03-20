using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    internal class ScaleCommand : Command
    {
        private List<Element> elementsOld = new List<Element>();
        private List<Element> elementsNew = new List<Element>();
        private float scale;
        public ScaleCommand(params object[] commandParameters) 
        {
            if (commandParameters.Length > 0) 
            {
                scale = (float) commandParameters[0];
            }
        }
        public override bool Execute()
        {
            List<Element> oldSet = TargetDrawing.GetAllSelected();
            foreach (Element element in oldSet)
            {
                if (element == null) continue;
                TargetDrawing.DeleteElement(element);
                elementsOld.Add(element.Clone());
                Element temp = element.Clone();
                temp.SetScale(scale);
                elementsNew.Add(temp);
            }
            foreach (Element element in elementsNew)
            {
                TargetDrawing.Add(element);
            }
            return true;
        }

        internal override void Redo()
        {
            foreach (Element element in elementsOld)
            {
                TargetDrawing.DeleteElement(element);
            }
            foreach (Element element in elementsNew)
            {
                TargetDrawing.Add(element);
            }
        }

        internal override void Undo()
        {
            foreach (Element element in elementsOld)
            {
                TargetDrawing.Add(element);
            }
            foreach (Element element in elementsNew)
            {
                TargetDrawing.DeleteElement(element);
            }
        }
    }
}
