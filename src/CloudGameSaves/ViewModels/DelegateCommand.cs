using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudGameSaves
{
  public class DelegateCommand : ICommand
  {
    private readonly Action _executeMethod;
    private readonly Func<bool> _canExecuteMethod;

    public DelegateCommand(Action executeMethod)
      : this(executeMethod, null)
    {

    }

    public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
      _executeMethod = executeMethod;
      _canExecuteMethod = canExecuteMethod;
    }

    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter)
      => _canExecuteMethod?.Invoke() ?? true;

    public void Execute(object parameter)
      => _executeMethod?.Invoke();
  }
}
