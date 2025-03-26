using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SauceDemo.WebDriver;

public static class WebDriverFactory
{
    public static IWebDriver Create(string browserName)
    {
        IWebDriver driver = browserName.ToLower() switch
        {
            "firefox" => new FirefoxDriver(),
            "edge" => new EdgeDriver(),
            _ => throw new ArgumentException($"Unsupported browser: {browserName}")
        };

        return driver;
    }
}
