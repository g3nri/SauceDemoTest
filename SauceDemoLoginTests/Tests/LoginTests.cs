
using Xunit;
using OpenQA.Selenium;
using SauceDemoLoginTests.Pages;
using SauceDemoLoginTests.Drivers;
using FluentAssertions;

namespace SauceDemoLoginTests.Tests;

public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;

    public LoginTests()
    {
        _driver = WebDriverFactory.Create("firefox"); // Или "edge"
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _loginPage = new LoginPage(_driver);
    }

    [Fact]
    public void UC1_LoginForm_ShowsError_WhenCredentialsAreEmpty()
    {
        _loginPage.EnterUsername("test");
        _loginPage.EnterPassword("test");
        _loginPage.ClearUsername();
        _loginPage.ClearPassword();
        _loginPage.ClickLogin();

        var error = _loginPage.GetErrorMessage();
        error.Should().Be("Username is required");
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
