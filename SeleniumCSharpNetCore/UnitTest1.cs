using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpNetCore.Pages;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpNetCore
{
    public class Tests : DriverHelper
    {
       

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            option.AddArguments("--headless");
            ChromeDriver chromeDriver = new ChromeDriver();
            Driver = chromeDriver;
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl  ("http://demowf.aspnetawesome.com");

            Driver.Manage().Window.Maximize();

            

            CustomControl.EnterText(Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")), "Tomato");

            CustomControl.Click(Driver.FindElement(By.XPath("//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Celery']")));

            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almonds");

            CustomControl.SelectByText(Driver.FindElement(By.Id("ContentPlaceHolder1_Add1-awed")) ,"Cauliflower");

           //CustomControl.SelectByValue(Driver)
          
            Assert.Pass();
        }

        [Test]
        public void LoginTest()

        {

            Driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();



            homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword("admin", "password");
            loginPage.ClickLogin();

            Assert.That(homePage.IsLogOffExist(), Is.True, "Log off button did not displayed");
        
        
        
        }
    }
}