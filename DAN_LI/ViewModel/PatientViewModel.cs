using DAN_LI.Service;
using DAN_LI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI.ViewModel
{
    class PatientViewModel:ViewModelBase
    {
        Patient patient;

        private tblPatient _currentPatient;
        public tblPatient currentPatient
        {
            get
            {
                return _currentPatient;
            }
            set
            {
                _currentPatient = value;
                OnPropertyChanged("currentPatient");
            }
        }

        public PatientViewModel(Patient open, tblPatient pat)
        {
            patient = open;
            currentPatient = pat;
        }

    }
}
