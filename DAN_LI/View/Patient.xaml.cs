using DAN_LI.Service;
using DAN_LI.ViewModel;
using System.Windows;

namespace DAN_LI.View
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient(tblPatient p)
        {
            InitializeComponent();
            this.DataContext = new PatientViewModel(this,p);
        }
    }
}
