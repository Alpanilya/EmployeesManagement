using System.Windows;

namespace EmployeesManagement.View
{
    public partial class DepartamentManagerWindow : Window
    {
        #region Name

        public static readonly DependencyProperty NameDepartamentProperty =
            DependencyProperty.Register(
                nameof(Name),
                typeof(string),
                typeof(DepartamentManagerWindow),
                new PropertyMetadata(default(string)));

        public string Name { get => (string)GetValue(NameDepartamentProperty); set => SetValue(NameDepartamentProperty, value); }

        #endregion
        public DepartamentManagerWindow()
        {
            InitializeComponent();
        }
    }
}
