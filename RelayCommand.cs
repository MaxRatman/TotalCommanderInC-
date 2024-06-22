using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TotalCommanderInC_
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
    public class RelayCommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;}
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecut= null)
        {
            this.execute = execute;
            this.canExecute = canExecut;
        }
        public bool CanExecute(object parameter) 
        {
            return this.canExecute == null|| this.canExecute(parameter);
        }
        public void Execute(object parameter) 
        {
            this.execute(parameter);
        }
    }
}
