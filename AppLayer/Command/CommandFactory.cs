using AppLayer.DrawingComponents;
using System;

namespace AppLayer.Command
{
    /// <summary>
    /// CommandFactory
    /// 
    /// Creates standard commands, but can be specialized to create custom commands.  This class is the base
    /// class in a factory method pattern.
    /// </summary>
    public class CommandFactory
    {
        private static CommandFactory _instance;
        private static readonly object MyLock = new object();
        private CommandFactory() { }
        // Trey: Command factory is a singleton handled by this instance
        public static CommandFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance==null)
                        _instance = new CommandFactory();
                }
                return _instance;
            }
        }

        public Drawing TargetDrawing { get; set; }
        public Invoker Invoker { get; set; }

        /// <summary>
        /// Create -- a factory method for standard commands 
        /// 
        /// This method can be overridden to generate different or custom commands.
        /// </summary>
        /// <param name="commandType">type of command to Create:
        ///             New
        ///             AddBird
        ///             AddLine
        ///             AddDraw
        ///             Remove
        ///             Select
        ///             Deselect
        ///             Load
        ///             Save</param>
        /// <param name="commandParameters">An array of optional parametesr whose sementics depedent on the command type
        ///     For new, no additional parameters needed
        ///     For add, 
        ///         [0]: Type       reference type for assembly containing the bird type resource
        ///         [1]: string     bird type -- a fully qualified resource name
        ///         [2]: Point      center location for the bird, defaut = top left corner
        ///         [3]: float      scale factor</param>
        ///     For remove, no additional parameters needed
        ///     For select,
        ///         [0]: Point      Location at which a bird could be selected
        ///     For deselect, no additional parameters needed
        ///     For load,
        ///         [0]: string     filename of file to load from  
        ///     For save,
        ///         [0]: string     filename of file to save to  
        /// <returns></returns>
        // Trey: here is the command factory that creates the commands and passes them on to the invoker to be run
        public virtual void CreateAndDo(string commandType, params object[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(commandType)) return;

            if (TargetDrawing == null) return;

            Command command=null;
            switch (commandType.Trim().ToUpper())
            {
                case "NEW":
                    command = new NewCommand();
                    break;
                case "ADDBIRD":
                    command = new AddBirdCommand(commandParameters);
                    break;
                case "ADDBOX":
                    command = new AddBoxCommand(commandParameters);
                    break;
                case "ADDLINE":
                    command = new AddLineCommand(commandParameters);
                    break;
                case "REMOVE":
                    command = new RemoveSelectedCommand();
                    break;
                case "SELECT":
                    command = new SelectCommand(commandParameters);
                    break;
                case "DESELECT":
                    command = new DeselectAllCommand();
                    break;
                case "LOAD":
                    command = new LoadCommand(commandParameters);
                    break;
                case "SAVE":
                    command = new SaveCommand(commandParameters);
                    break;
                // Commands that are added, very simple add new commands once set up
                case "SETBACKGROUND":
                    command = new SetBackgroundCommand(commandParameters);
                    break;
                case "EXPORT":
                    command = new ExportCommand(commandParameters);
                    break;
                case "MOVE":
                    command = new MoveCommand(commandParameters);
                    break;
                case "CLONE":
                    command = new CloneCommand(commandParameters);
                    break;
                case "SCALE":
                    command = new ScaleCommand(commandParameters);
                    break;
            }

            if (command != null)
            {
                command.TargetDrawing = TargetDrawing;
                Invoker.EnqueueCommandForExecution(command);
            }
        }
    }
}

