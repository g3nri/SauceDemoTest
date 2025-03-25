using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SauceDemoLoginTests.Utilities;

namespace SauceDemoLoginTests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    private IWebElement Username => _driver.FindElement(By.CssSelector("#user-name"));
    private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
    private IWebElement LoginButton => _driver.FindElement(By.CssSelector("#login-button"));
    private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));

    private void ClearInput(IWebElement element)
    {
        element.Click();
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(Keys.Backspace);
        element.Clear();
    }

    public void SetCredentials(string username, string password)
    {
        Logger.Log.Info($"Set username: {username}, password: {password}");
        ClearInput(Username);
        Username.SendKeys(username);
        ClearInput(Password);
        Password.SendKeys(password);
    }

    public void ClearCredentials()
    {
        Logger.Log.Info("Clear login and password fields");
        ClearInput(Username);
        ClearInput(Password);
    }

    public void ClickLogin()
    {
        Logger.Log.Info("Click login button");
        LoginButton.Click();
    }

    public string GetErrorMessage()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='error']")));
        var error = ErrorMessage.Text;
        Logger.Log.Info($"Captured error: {error}");
        return error;
    }
}
