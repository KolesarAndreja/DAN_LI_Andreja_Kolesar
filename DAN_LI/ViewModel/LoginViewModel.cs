using DAN_LI.Command;
using DAN_LI.Service;
using DAN_LI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LI.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        Login login;
        private tblUser _currentUser;
        public tblUser currentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged("currentUser");
            }
        }
        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
            currentUser = new tblUser();
        }

        #region Commands
        private ICommand _loginBtn;
        public ICommand loginBtn
        {
            get
            {
                if (_loginBtn == null)
                {
                    _loginBtn = new RelayCommand(LoginExecute, CanLoginExecute);
                }
                return _loginBtn;
            }
        }

        private void LoginExecute(object obj)
        {
            currentUser.password = (obj as PasswordBox).Password;
            try
            {
                currentUser = Service.Service.GetUserByUsernameAndPsw(currentUser.username, currentUser.password);
                if (currentUser == null)
                {
                    MessageBox.Show("Invalid username or password.Try again");
                }
                else
                {
                    if (Service.Service.isPatient(currentUser) != null)
                    {
                        tblPatient currentPatient = Service.Service.isPatient(currentUser);
                        Patient pat = new Patient(currentPatient);
                        login.Close();
                        pat.Show();
                    }
                    else
                    {
                        tblDoctor currentDoctor = Service.Service.isDoctor(currentUser);
                        Doctor doc = new Doctor(currentDoctor);
                        login.Close();
                        doc.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute(object obj)
        {
            return true;
        }
        #endregion

        #region REGISTRATION

        private ICommand _registration;
        public ICommand registration
        {
            get
            {
                if (_registration == null)
                {
                    _registration = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _registration;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                Registration reg = new Registration();
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
