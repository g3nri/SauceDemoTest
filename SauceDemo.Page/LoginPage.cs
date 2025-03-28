using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Page;

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

    private static void ClearInput(IWebElement element)
    {
        element.Click();
        element.SendKeys(Keys.Control + "a"); //<-- for Windows users
        element.SendKeys(Keys.Command + "a"); //<-- for Mac users
        element.SendKeys(Keys.Delete);
    }

    public void SetCredentials(string username, string password)
    {
        Username.SendKeys(username);
        Password.SendKeys(password);
    }

    public void ClearCredentials()
    {
        ClearInput(Username);
        ClearInput(Password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }

    public string GetErrorMessage()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-test='error']")));
        var error = ErrorMessage.Text;
        return error;
    }
}
