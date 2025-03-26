using OpenQA.Selenium;
using FluentAssertions;
using SauceDemo.WebDriver;
using SauceDemo.Page;
using SauceDemo.Common;
using TechTalk.SpecFlow;

namespace SauceDemo.UITests;

[Binding]
public class LoginSteps
{
    private IWebDriver _driver = null!;
    private LoginPage _loginPage = null!;

    [Given(@"I open the login page")]
    public void GivenIOpenTheLoginPage()
    {
        Logger.Log.Info("Opening login page");
        _driver = WebDriverFactory.Create("edge");
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _loginPage = new LoginPage(_driver);
    }

    [When(@"I enter username ""(.*)"" and password ""(.*)""")]
    public void WhenIEnterUsernameAndPassword(string username, string password)
    {
        Logger.Log.Info($"Entering username: {username}, password: {password}");
        _loginPage.SetCredentials(username, password);
    }

    [When(@"I clear both username and password fields")]
    public void WhenIClearBothFields()
    {
        Logger.Log.Info("Clearing both username and password fields");
        _loginPage.ClearCredentials();
    }

    [When(@"I click the login button")]
    public void WhenIClickLogin()
    {
        Logger.Log.Info("Clicking the login button");
        _loginPage.ClickLogin();
    }

    [Then(@"I should see the error message ""(.*)""")]
    public void ThenIShouldSeeError(string expected)
    {
        var actual = _loginPage.GetErrorMessage();
        Logger.Log.Info($"Expected error: '{expected}', Actual error: '{actual}'");
        actual.Should().Be(expected);
        _driver.Quit();
    }

    [Then(@"I should see the page title ""(.*)""")]
    public void ThenIShouldSeeTitle(string expectedTitle)
    {
        Logger.Log.Info($"Validating page title: expected '{expectedTitle}'");
        _driver.Title.Should().Be(expectedTitle);
        _driver.Quit();
    }
}