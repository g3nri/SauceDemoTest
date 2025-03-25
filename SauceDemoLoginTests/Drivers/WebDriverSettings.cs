
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SauceDemoLoginTests.Drivers;

public static class WebDriverSettings
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
