using DAN_LI.Command;
using DAN_LI.Service;
using DAN_LI.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DAN_LI.ViewModel
{
    class RegistrationViewModel:ViewModelBase
    {
        #region Prop
        Registration registration;
        private tblUser _newUser;
        public tblUser newUser
        {
            get
            {
                return _newUser;
            }
            set
            {
                _newUser = value;
                OnPropertyChanged("newUser");
            }
        }

        private tblDoctor _newDoctor;
        public tblDoctor newDoctor
        {
            get
            {
                return _newDoctor;
            }
            set
            {
                _newDoctor = value;
                OnPropertyChanged("newDoctor");
            }
        }

        private tblPatient _newPatient;
        public tblPatient newPatient
        {
            get
            {
                return _newPatient;
            }
            set
            {
                _newPatient = value;
                OnPropertyChanged("newPatient");
            }
        }

        private List<vwDoctor> _doctorList;
        public List<vwDoctor> doctorList
        {
            get
            {
                return _doctorList;
            }
            set
            {
                _doctorList = value;
                OnPropertyChanged("doctorList");
            }
        }



        private tblDoctor _selectedDoctor;
        public tblDoctor selectedDoctor
        {
            get
            {
                return _selectedDoctor;
            }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged("selectedDoctor");
            }
        }
        #endregion

        #region constructor
        public RegistrationViewModel(Registration open)
        {
            registration = open;
            newUser = new tblUser();
            newDoctor = new tblDoctor();
            newPatient = new tblPatient();
            selectedDoctor = new tblDoctor();
            doctorList = Service.Service.GetDoctorsList();
        }
        #endregion

        #region Visibility
        private Visibility _viewDoctor = Visibility.Collapsed;
        public Visibility viewDoctor
        {
            get
            {
                return _viewDoctor;
            }
            set
            {
                _viewDoctor = value;
                OnPropertyChanged("viewDoctor");
            }
        }
        private Visibility _viewPatient = Visibility.Collapsed;
        public Visibility viewPatient
        {
            get
            {
                return _viewPatient;
            }
            set
            {
                _viewPatient = value;
                OnPropertyChanged("viewPatient");
            }
        }
        private ICommand _createDoctor;
        public ICommand createDoctor
        {
            get
            {
                if (_createDoctor == null)
                {
                    _createDoctor = new RelayCommand(param => CreateDoctorExecute(), param => CanCreateDoctorExecute());
                }
                return _createDoctor;
            }
        }

        private void CreateDoctorExecute()
        {

            try
            {

                if (viewPatient == Visibility.Visible)
                {
                    viewPatient = Visibility.Collapsed;
                }
                viewDoctor = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreateDoctorExecute()
        {
            return true;
        }

        private ICommand _createPatient;
        public ICommand createPatient
        {
            get
            {
                if (_createPatient == null)
                {
                    _createPatient = new RelayCommand(param => CreatePatientExecute(), param => CanCreatePatientExecute());
                }
                return _createPatient;
            }
        }

        private void CreatePatientExecute()
        {

            try
            {
                if (viewDoctor == Visibility.Visible)
                {
                    viewDoctor = Visibility.Hidden;
                }
                viewPatient = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCreatePatientExecute()
        {
            return true;
        }
        #endregion

        #region Commands

        private ICommand _save1;
        public ICommand save1
        {
            get
            {
                if (_save1 == null)
                {
                    _save1 = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save1;
            }
        }

        private void SaveExecute()
        {
            try
            {

                //tblUser e = Service.Service.AddUser(newUser);
                //newDoctor.userId = e.userId;
                //newDoctor.qualificationId = qualification.id;
                //tblManager me = Service.Service.AddManager(newDoctor);

                //if (e != null && me != null)
                //{
                //    MessageBox.Show("Manager has been succesfully created!");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            //if (Service.Service.IsValidUser(newUser.username, newUser.password) == null && !String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.email) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        private ICommand _save2;
        public ICommand save2
        {
            get
            {
                if (_save2 == null)
                {
                    _save2 = new RelayCommand(param => Save2Execute(), param => CanSave2Execute());
                }
                return _save2;
            }
        }

        private void Save2Execute()
        {
            try
            {
                //tblUser e = Service.Service.AddUser(newUser);
                //newPatient.userId = e.userId;
                //newPatient.genderId = gender.id;
                //newPatient.engegamentId = engagement.id;
                //tblStaff me = Service.Service.AddStaff(newPatient);

                //if (e != null && me != null)
                //{
                //    MessageBox.Show("Staff has been succesfully created!");
                //}
                //else
                //{
                //    MessageBox.Show("Error. Try again.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSave2Execute()
        {
        //    if (Service.Service.IsValidUser(newUser.username, newUser.password) == null && !String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.email) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        return true;
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
                registration.Close();

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
        #endregion
    }
}
}
