using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace Birds
{
    // NOTE: There some design problems with this class

    public partial class MainForm : Form
    {
        private readonly Drawing _drawing;
        private bool _forceRedraw;
        private readonly Invoker _invoker;
        private string _currentBirdResource;
        private float _currentScale = 1;
        private bool _showRubberBand;
        private bool _eraseLastRubberBand;
        private Point _startingPoint;
        private Point _lastRubberBandEnd;
        private Point _rubberBandStart;
        private Point _rubberBandEnd;


        private enum PossibleModes
        {
            None,
            BirdDrawing,
            LineDrawing,
            BoxDrawing,
            Selection,
            Moving,
            Clone
        };

        private PossibleModes _mode = PossibleModes.None;

        private Bitmap _imageBuffer;
        private Graphics _imageBufferGraphics;
        private Graphics _panelGraphics;
       
        public MainForm()
        {
            InitializeComponent();

            BirdFactory.Instance.ResourceNamePattern = @"Birds.Graphics.{0}.png";
            BirdFactory.Instance.ReferenceType = typeof(Program);

            _drawing = new Drawing();
            _invoker = new Invoker();
            CommandFactory.Instance.TargetDrawing = _drawing;
            CommandFactory.Instance.Invoker = _invoker;

            _invoker.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing();
        }

        private void DisplayDrawing()
        {
            if (_imageBuffer == null)
            {
                _imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                _imageBufferGraphics = Graphics.FromImage(_imageBuffer);
                _panelGraphics = drawingPanel.CreateGraphics();
            }

            if (_drawing.Draw(_imageBufferGraphics, _forceRedraw))
                _panelGraphics.DrawImageUnscaled(_imageBuffer, 0, 0);

            _forceRedraw = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndDo("new"); // Clear backgrounds and elements
            this.SetBackgroundBtn.PerformClick(); //Trey: Here is requirement 1, calls the set background on new, I also added a set background button to do it any time
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (var item in drawingToolStrip.Items)
            {
                var toolButton = item as ToolStripButton;
                if (toolButton != null && item!=ignoreItem && toolButton.Checked )
                    toolButton.Checked = false;
            }
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button!=null && button.Checked)
            {
                _mode = PossibleModes.Selection;
                _currentBirdResource = string.Empty;
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }

        private void BirdButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
                _currentBirdResource = button.Text;
            else
                _currentBirdResource = string.Empty;

            CommandFactory.Instance.CreateAndDo("deselect");
            _mode = (_currentBirdResource != string.Empty) ? PossibleModes.BirdDrawing : PossibleModes.None;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_mode)
            {
                case PossibleModes.BoxDrawing:
                    {
                        var form = new LabelBoxForm
                        {
                            DesktopLocation = 
                                new Point(ClientRectangle.Left + e.Location.X,
                                    ClientRectangle.Top + e.Location.Y)
                        };

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var minX = Math.Min(_startingPoint.X, e.Location.X);
                            var maxX = Math.Max(_startingPoint.X, e.Location.X);
                            var minY = Math.Min(_startingPoint.Y, e.Location.Y);
                            var maxY = Math.Max(_startingPoint.Y, e.Location.Y);

                            var size = new Size() {Width = maxX - minX, Height = maxY - minY};
                            CommandFactory.Instance.CreateAndDo("addbox", form.LabelText, _startingPoint, size);
                        }
                        break;
                    }
                case PossibleModes.LineDrawing:
                    CommandFactory.Instance.CreateAndDo("addline", _startingPoint, e.Location);
                    break;
                case PossibleModes.BirdDrawing:
                    if (!string.IsNullOrWhiteSpace(_currentBirdResource))
                        CommandFactory.Instance.CreateAndDo("addBird", _currentBirdResource, e.Location, _currentScale);
                    break;
                case PossibleModes.Selection:
                    CommandFactory.Instance.CreateAndDo("select", e.Location);
                    break;
                case PossibleModes.Moving:
                    CommandFactory.Instance.CreateAndDo("move", e.Location);
                    break;
                case PossibleModes.Clone:
                    CommandFactory.Instance.CreateAndDo("clone", e.Location);
                    break;
            }

            _showRubberBand = false;
            _eraseLastRubberBand = false;
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
            scale.Text = _currentScale.ToString(CultureInfo.InvariantCulture);
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            var result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                result = !float.TryParse(text, out result) ? defaultValue : Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "json",
                Multiselect = false,
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("load", dialog.FileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "json",
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("save", dialog.FileName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
        }

        private void ComputeDrawingPanelSize()
        {
            var width = Width - drawingToolStrip.Width;
            var height = Height - fileToolStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, fileToolStrip.Height);

            _imageBuffer = null;

            _forceRedraw = true;
        }



        private void deleteButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndDo("remove");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _invoker?.Stop();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            _invoker.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            _invoker.Redo();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _mode = PossibleModes.LineDrawing;
        }

        private void labelBoxButton_Click(object sender, EventArgs e)
        {
            _mode = PossibleModes.BoxDrawing;
        }
        // Setting the background
        private void SetBackgroundBtn_Click(object sender, EventArgs e)
        {
            Bitmap backgroundMap = null;
            using (BackgroundSelect backgroundSelect = new BackgroundSelect())
            {
                var map = backgroundSelect.ShowDialog();
                if (map == DialogResult.OK)
                {
                    backgroundMap = backgroundSelect.BackgroundMap;
                    // Resize the selected image/color to be our canvas size before passing it along
                    backgroundMap = new Bitmap(backgroundMap, _imageBuffer.Width, _imageBuffer.Height);
                    CommandFactory.Instance.CreateAndDo("setbackground", backgroundMap);
                }
            }
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mode != PossibleModes.BoxDrawing && _mode != PossibleModes.LineDrawing) return;

            _startingPoint = e.Location;
            _rubberBandStart = ComputeAbsolutePoint(e.Location);          
            _showRubberBand = true;
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_showRubberBand) return;

            _rubberBandEnd = ComputeAbsolutePoint(e.Location);

            switch (_mode)
            {
                case PossibleModes.LineDrawing:
                    DrawRubberBandLine();
                    break;
                case PossibleModes.BoxDrawing:
                    DrawRubberBandBox();
                    break;
            }

            _eraseLastRubberBand = true;
            _lastRubberBandEnd = _rubberBandEnd;
        }

        private void DrawRubberBandLine()
        {

            if (_eraseLastRubberBand)
                EraseOldRubberBandLine();

            ControlPaint.DrawReversibleLine(_rubberBandStart, _rubberBandEnd, Color.Gray);
        }

        private void EraseOldRubberBandLine()
        {
            ControlPaint.DrawReversibleLine(_rubberBandStart, _lastRubberBandEnd, Color.Gray);
        }

        private void DrawRubberBandBox()
        {
            if (_eraseLastRubberBand)
                EraseOldRubberBandFrame();

            var rectangle = new Rectangle(_rubberBandStart.X, _rubberBandStart.Y,
                                        _rubberBandEnd.X - _rubberBandStart.X, _rubberBandEnd.Y - _rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(rectangle, Color.Gray, FrameStyle.Dashed);
        }

        private void EraseOldRubberBandFrame()
        {
            var oldRectangle = new Rectangle(_rubberBandStart.X, _rubberBandStart.Y,
                                        _lastRubberBandEnd.X - _rubberBandStart.X, _lastRubberBandEnd.Y - _rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(oldRectangle, Color.Gray, FrameStyle.Dashed);
        }

        private Point ComputeAbsolutePoint(Point location)
        {
            var p1 = this.PointToScreen(new Point(0, 0));
            var p2 = drawingPanel.PointToScreen(new Point(0, 0));

            var p4 = drawingPanel.PointToScreen(
                        new Point(drawingPanel.ClientRectangle.Left + location.X,
                        drawingPanel.ClientRectangle.Top + location.Y));
            return p4;
        }

        private void ExportPNG_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "png",
                RestoreDirectory = true,
                Filter = @"PNG files (*.png)|*.png|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("export", dialog.FileName, _imageBuffer); // _imageBuffer is the image everything has been drawn to
            }
        }

        private void MoveSelectedButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                _mode = PossibleModes.Moving;
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }

        private void CloneElementBtn_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                _mode = PossibleModes.Clone;
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }

        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;

            CommandFactory.Instance.CreateAndDo("scale", _currentScale);

        }
        // Trey: Requirement 4 key bindings
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.scale.Focused) return false; // If we are on text box, take in data instead
            switch (keyData)
            {
                case Keys.S:
                    this.pointerButton.PerformClick();
                    break;
                case Keys.C:
                    this.CloneElementBtn.PerformClick();
                    break;
                case Keys.M:
                    this.MoveSelectedButton.PerformClick();
                    break;
                case Keys.F:
                    this.ScaleBtn.PerformClick();
                    break;
                case Keys.N:
                    this.newButton.PerformClick();
                    break;
                case Keys.O:
                    this.openButton.PerformClick();
                    break;
                case Keys.P:
                    this.saveButton.PerformClick();
                    break;
                case Keys.E:
                    this.ExportPNG.PerformClick();
                    break;
                case Keys.D:
                    this.deleteButton.PerformClick();
                    break;
                case Keys.U:
                    this.undoButton.PerformClick();
                    break;
                case Keys.R:
                    this.redoButton.PerformClick();
                    break;
                case Keys.B:
                    this.SetBackgroundBtn.PerformClick();
                    break;
            }
            return true;
        }

    }
}
