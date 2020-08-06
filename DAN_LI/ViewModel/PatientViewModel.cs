using DAN_LI.Command;
using DAN_LI.Service;
using DAN_LI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                Login login = new Login();
                patient.Close();
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }

        #region sick leave

        private ICommand _requirement;
        public ICommand requirement
        {
            get
            {
                if (_requirement == null)
                {
                    _requirement = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _requirement;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                SickLeave reg = new SickLeave();
                reg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegistrationExecute()
        {
            return true;
        }
        #endregion
    }
}
