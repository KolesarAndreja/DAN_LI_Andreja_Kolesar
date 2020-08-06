using DAN_LI.Service;
using DAN_LI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI.ViewModel
{
    class DoctorViewModel:ViewModelBase
    {
        Doctor doctor;

        private tblDoctor _currentDoctor;
        public tblDoctor currentDoctor
        {
            get
            {
                return _currentDoctor;
            }
            set
            {
                _currentDoctor = value;
                OnPropertyChanged("currentDoctor");
            }
        }

        public DoctorViewModel(Doctor open, tblDoctor doc)
        {
            doctor = open;
            currentDoctor = doc;
        }
    }
}
