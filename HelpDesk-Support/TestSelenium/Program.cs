using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44311/");
            driver.Manage().Window.Maximize();

            //inicio de sesion
           IWebElement email = driver.FindElement(By.Id("emailLogin"));
           email.SendKeys("jenni@gmail.com");

            IWebElement password = driver.FindElement(By.Id("passwordLogin"));
            password.SendKeys("hola");

            IWebElement button = driver.FindElement(By.Id("iniciar-sesion"));
            button.Click();
            //prueba para buscar 
            IWebElement solicitudes = driver.FindElement(By.Id("addSupporter"));
            solicitudes.Click();

            IWebElement name = driver.FindElement(By.Id("name"));
            name.SendKeys("Carmen");

            IWebElement firstSurname = driver.FindElement(By.Id("first-surname"));
            firstSurname.SendKeys("Salinas");

            IWebElement secondSurname = driver.FindElement(By.Id("second-surname"));
            secondSurname.SendKeys("Mora");

            IWebElement email2 = driver.FindElement(By.Id("email"));
            email2.SendKeys("carmen@gmail.com");

            IWebElement password2 = driver.FindElement(By.Id("password"));
            password2.SendKeys("123");

            IWebElement add = driver.FindElement(By.Id("add-supporter-btn"));
            add.Click();
           

        }
    }
}
