using FluentAssertions;
using OpenQA.Selenium;
using SauceDemo.WebDriver;
using SauceDemo.Page;
using SauceDemo.Common;
using Xunit;

namespace SauceDemo.UITests;

public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;

    public LoginTests()
    {
        Logger.Log.Info("Initializing WebDriver");
        _driver = WebDriverFactory.Create("firefox"); // <-browser edge or firefox
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _loginPage = new LoginPage(_driver);
    }
    
    [Fact]
    public void UC1_ShouldShowUsernameRequired_WhenCredentialsAreEmpty()
    {
        Logger.Log.Info("UC-1: Test Login form with empty credentials");

        _loginPage.SetCredentials("test", "test");
        _loginPage.ClearCredentials();
        _loginPage.ClickLogin();

        var error = _loginPage.GetErrorMessage();
        error.Should().Be("Epic sadface: Username is required");
    }
    
    [Fact]
    public void UC2_ShouldShowPasswordRequired_WhenPasswordIsEmpty()
    {
        Logger.Log.Info("UC-2: Test Login form with empty password");

        _loginPage.SetCredentials("test", "");
        _loginPage.ClickLogin();

        var error = _loginPage.GetErrorMessage();
        error.Should().Be("Epic sadface: Password is required");
    }

    [Theory]
    [InlineData("standard_user")]
    [InlineData("problem_user")]
    [InlineData("performance_glitch_user")]
    public void UC3_ShouldLoginSuccessfully_WithValidCredentials(string username)
    {
        Logger.Log.Info($"UC-3: Test successful login for user '{username}'");

        _loginPage.SetCredentials(username, "secret_sauce");
        _loginPage.ClickLogin();

        _driver.Title.Should().Be("Swag Labs");
    }

    public void Dispose()
    {
        Logger.Log.Info("Closing WebDriver");
        _driver.Quit();
    }
}