using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp1.Comms
{
    public abstract class commBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecuteChanged()
        {

            CanExecuteChanged?.Invoke(this, new EventArgs());
        }


    }
}
