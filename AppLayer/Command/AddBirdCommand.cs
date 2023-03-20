using System;
using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddBirdCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string _birdType;
        private Point _location;
        private readonly float _scale;
        private Element _birdAdded;
        internal AddBirdCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     bird type -- a fully qualified resource name
        ///     [2]: Point      center location for the bird, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddBirdCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _birdType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                _location = (Point) commandParameters[1];
            else
                _location = new Point(0, 0);

            if (commandParameters.Length > 2)
            {
                _scale = (float) commandParameters[2];
            }
            else
                _scale = 1.0F;
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(_birdType) || TargetDrawing==null) return false;

            var birdSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
            var birdLocation = new Point(_location.X - birdSize.Width / 2, _location.Y - birdSize.Height / 2);

            var extrinsicState = new BirdExtrinsicState()
            {
                BirdType = _birdType,
                Location = birdLocation,
                Size = birdSize
            };
            _birdAdded = BirdFactory.Instance.GetBird(extrinsicState);
            TargetDrawing.Add(_birdAdded);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(_birdAdded);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_birdAdded);
        }
    }
}
