﻿using MovieLib.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class LoginViewModel:BaseViewModel
    {
        public string? Username { get; set; }    
        public string? Password { get; set; }
        public ICommand LoginCommand { get; set; }
       
        public LoginViewModel()
        {
            LoginCommand = new RelyCommand(() => { });
        }

        public void login()
        {
            SecondWindow win = new SecondWindow();

        }
    }
}
