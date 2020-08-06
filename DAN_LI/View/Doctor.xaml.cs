using DAN_LI.Service;
using DAN_LI.ViewModel;
using System.Windows;

namespace DAN_LI.View
{
    /// <summary>
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        public Doctor(tblDoctor d)
        {
            InitializeComponent();
            this.DataContext = new DoctorViewModel(this, d);
        }
    }
}
