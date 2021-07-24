using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpNetCore.Pages
{
    class HomePage: DriverHelper
    {
        IWebElement lnkLogin => Driver.FindElement(By.LinkText("Login"));

        IWebElement lnkLogoff => Driver.FindElement(By.LinkText("Log off"));

        
        public void ClickLogin()
        {
            lnkLogin.Click();
        }

        public bool IsLogOffExist() => lnkLogoff.Displayed;
        
 


    }
}
