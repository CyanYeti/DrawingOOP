using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class NewCommand : Command
    {
        private List<Element> _previousElements;
        private List<Background> _previousBackgrounds;
        internal NewCommand() {}

        public override bool Execute()
        {
            _previousElements = TargetDrawing.GetCloneOfElements();
            _previousBackgrounds = TargetDrawing.GetBackgrounds();
            TargetDrawing?.Clear();
            return _previousElements != null && _previousElements.Count > 0;
        }

        internal override void Undo()
        {
            if (_previousElements == null || _previousElements.Count == 0) return;

            foreach (var element in _previousElements)
                TargetDrawing?.Add(element);
            foreach (var background in _previousBackgrounds)
            {
                TargetDrawing?.SetBackground(background);
            }
        }

        internal override void Redo()
        {
            Execute();
        }
    }
}
