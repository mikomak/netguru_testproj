using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    class StaticPageElements : Setup
    {
        public static string createAccOrLogInElement = "span[data-cy='common_link_header_myaccount']";
        public static string registerTabSwitcherElement = "a[id='register_tab']";
        public static string loginTabSwitcherElement = "a[id='login_tab']";
        public static string emailRegisterElement = "input[name='register[email]']";
        public static string emailLoginElement = "input[name='login[email]']";
        public static string passwordRegisterElement = "input[name='register[password]']";
        public static string passwordLoginElement = "input[name='login[password]']";
        public static string loginFormErrorMessageElement = "div[class='errorboxContainer']";
        public static string conditionsAndTermsElement = "p[class='login-form__terms']";
        public static string loginButton = "button[id*=se_userLogin]";
        public static string registerButton = "button[id*=button_register]"; 
    }
}
