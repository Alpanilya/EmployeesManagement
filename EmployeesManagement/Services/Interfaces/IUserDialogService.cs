using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Services.Interfaces
{
    interface IUserDialogService
    {

        void ShowInfo(string information, string caption);
        void ShowWarning(string message, string caption);
        void ShowError(string message, string caption);
        bool Edit(object item);
        bool Confirm(string message, string caption, bool exlamanation = false);
        bool Create(object item);
    }
}
