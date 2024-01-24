using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace UnitTestGosuslugiTest
{
    [TestFixture]
    class Chrome
    {
        private IWebDriver driver;
        private readonly By _SigninButton = By.XPath("//button[text()='Войти']");
        private readonly By _QuestionButton = By.XPath("//button[text()=' Не удаётся войти? ']");
        private readonly By _RecoverButton = By.XPath("//button[text()=' восстановления пароля ']");
        private readonly By _ActualText = By.XPath("//h3[@class='title-h3 mb-24 text-center']");//имя найденой формы

        private const string _excented = "Восстановление пароля";//имя нужной формы

        [SetUp]
        public void initialize()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");//открытие страницы госуслуг
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            var signin = driver.FindElement(_SigninButton);//находим кнопку войти
            signin.Click();//нажатие на кнопку войти
            Thread.Sleep(800);
            var question = driver.FindElement(_QuestionButton);//находим кнопку Не удается войти?
            question.Click();//нажатие на кнопку Не удается войти?
            Thread.Sleep(800);
            var recover = driver.FindElement(_RecoverButton);//находим кнопку восстановление пароля
            recover.Click();//нажатие на кнопку восстановление пароля
            Thread.Sleep(800);
            var actual = driver.FindElement(_ActualText).Text;//считываем имя формы

            Assert.That(actual,Is.EquivalentTo(_excented));//проверка на нужную форму
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}
