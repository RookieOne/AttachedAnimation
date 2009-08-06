using System;
using System.Windows.Input;

namespace AttachedAnimations.Commands
{
    /// <summary>
    /// Action Command
    /// </summary>
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (_action != null)
                _action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}