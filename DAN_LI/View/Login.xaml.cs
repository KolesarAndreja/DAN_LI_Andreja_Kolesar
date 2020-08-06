﻿using DAN_LI.ViewModel;
using System.Windows;

namespace DAN_LI.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(this);
        }
    }
}
