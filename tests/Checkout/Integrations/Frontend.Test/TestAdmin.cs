namespace Frontend.Test;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

public class TestAdmin
{
    public static void Run()
    {
        IWebDriver driver = new EdgeDriver();

        driver.Navigate().GoToUrl("http://localhost:5173/login");

        Thread.Sleep(5000);

        void TestaFuncaoAdmin(int i)
        {
            //acessar o campo ra atraves do ID
            var fieldEmail = driver.FindElement(By.Id("email"));
            //limpar o campo
            fieldEmail.Clear();
            //preencher o campo com o valor
            fieldEmail.SendKeys("admin@email.com");

            var fieldPassword = driver.FindElement(By.Id("password"));
            fieldPassword.Clear();
            fieldPassword.SendKeys("password");

            //acessa o botao de gravar
            var buttonEntrar = driver.FindElement(By.Id("btnLogin"));
            //executa o click
            buttonEntrar.Click();

            //aguarda 3 segundos para que a requisição seja concluida no backend
            Thread.Sleep(5000);

            buttonEntrar.Click();

        }
        for (var i = 0; i < 1; i++)
        {
            TestaFuncaoAdmin(i);
            //fecha a janela do navegador
            //driver.Quit();
        }

    }

}
