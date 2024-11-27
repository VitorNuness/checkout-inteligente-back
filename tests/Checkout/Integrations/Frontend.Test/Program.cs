namespace Frontend.Test;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    public static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("http://localhost:5173/signup");

        void TestUser(int i)
        {


            var fieldName = driver.FindElement(By.Id("name"));
            fieldName.Clear();
            fieldName.SendKeys("Joao");

            var fieldEmail = driver.FindElement(By.Id("email"));
            fieldEmail.Clear();
            fieldEmail.SendKeys("teste@aaaa.com");

            var filedEmailConfirmation = driver.FindElement(By.Id("emailConfirmation"));
            filedEmailConfirmation.Clear();
            filedEmailConfirmation.SendKeys("teste@aaaa.com");

            var fieldPassword = driver.FindElement(By.Id("password"));
            fieldPassword.Clear();
            fieldPassword.SendKeys("abcd1234");

            var fieldPasswordConfirmation = driver.FindElement(By.Id("passwordConfirmation"));
            fieldPasswordConfirmation.Clear();
            fieldPasswordConfirmation.SendKeys("abcd1234");

            var fieldCheckBox = driver.FindElement(By.Id("terms"));
            fieldCheckBox.Click();


            var buttonGravar = driver.FindElement(By.Id("btnGravar"));
            buttonGravar.Click();

            Thread.Sleep(1000);


            var botaoMouse = driver.FindElement(By.CssSelector("#app > div.mais-vendidos-container > div > div:nth-child(3) > div > div > div.card-body.justify-content-between > button"));
            botaoMouse.Click();

            Thread.Sleep(1000);


            var botaoCarrinho = driver.FindElement(By.CssSelector("#app > header > div > nav > div > div:nth-child(2) > ul > div > li:nth-child(1) > button"));
            botaoCarrinho.Click();

            Thread.Sleep(1500);

            var botaoFinal = driver.FindElement(By.Id("btnFinalizar"));
            botaoFinal.Click();

        }
        for (var i = 0; i < 1; i++)
        {
            TestUser(i);

        }
        //driver.Quit();
    }
}