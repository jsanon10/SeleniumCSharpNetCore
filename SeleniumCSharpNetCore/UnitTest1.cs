using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            ChromeDriver chromeDriver = new ChromeDriver(option);
            Driver = chromeDriver;
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl  ("http://demowf.aspnetawesome.com");

            Driver.Manage().Window.Maximize();

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            Driver.FindElement(By.XPath("//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Celery']")).Click();


            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almonds");
          
            Assert.Pass();
        }
    }
}