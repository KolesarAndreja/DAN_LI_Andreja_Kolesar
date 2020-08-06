using DAN_LI.ViewModel;
using System.Windows;

namespace DAN_LI.View
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this);
        }

    }
}
