using EmployeesManagement.Command.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Command
{
    internal class LambdaCommand : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            _Execute = Execute ?? throw new ArgumentNullException();
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _Execute(parameter);
        }
    }
}
