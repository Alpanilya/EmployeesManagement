using System.Windows;

namespace EmployeesManagement.View
{
    public partial class EmployeeManagerWindow : Window
    {
        #region FirstName

        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register(
                nameof(FirstName),
                typeof(string),
                typeof(EmployeeManagerWindow),
                new PropertyMetadata(default(string)));

        public string FirstName { get => (string)GetValue(FirstNameProperty); set => SetValue(FirstNameProperty, value); }

        #endregion

        #region LastName

        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                nameof(LastName),
                typeof(string),
                typeof(EmployeeManagerWindow),
                new PropertyMetadata(default(string)));

        public string LastName { get => (string)GetValue(LastNameProperty); set => SetValue(LastNameProperty, value); }

        #endregion

        #region Age

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                nameof(Age),
                typeof(int),
                typeof(EmployeeManagerWindow),
                new PropertyMetadata(default(int)));

        public int Age { get => (int)GetValue(RatingProperty); set => SetValue(RatingProperty, value); }

        #endregion

        #region Position

        public static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register(
                nameof(Position),
                typeof(string),
                typeof(EmployeeManagerWindow),
                new PropertyMetadata(default(string)));

        public string Position { get => (string)GetValue(PatronymicProperty); set => SetValue(PatronymicProperty, value); }

        #endregion
        public EmployeeManagerWindow()
        {
            InitializeComponent();
        }
    }
}
