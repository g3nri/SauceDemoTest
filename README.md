# SauceDemo UI Automation Tests

This project provides automated UI testing for the SauceDemo website (https://www.saucedemo.com/) using Selenium WebDriver, xUnit, SpecFlow (BDD), FluentAssertions, logging with Serilog, and the Page Object Model (POM) design pattern.

## 🚀 Technologies

- **C# / .NET**
- **Selenium WebDriver**
- **xUnit**
- **SpecFlow (BDD)**
- **FluentAssertions**
- **Serilog**
- **WebDriver (Edge and Firefox)**

## ✅ Supported Browsers

- Firefox
- Edge

## 📚 Test Scenarios

The tests cover the following User Scenarios (UC):

| ID   | Description                                | Status  |
|------|--------------------------------------------|---------|
| UC-1 | Login form validation with empty inputs    | ✅ Done |
| UC-2 | Login form validation with empty password  | ✅ Done |
| UC-3 | Successful login validation                | ✅ Done |

## 🛠 Project Structure

- `Pages/` - Page Object classes
- `Drivers/` - WebDriver configuration (supports Edge and Firefox)
- `Tests/` - Test classes
- `StepDefinitions/` - SpecFlow definitions
- `Utilities/` - Logging utilities

## ⚙️ Setup and Run

1. Clone this repository
2. Install dependencies:
```bash
dotnet restore
```
3. Download WebDrivers:
   - [Firefox GeckoDriver](https://github.com/mozilla/geckodriver/releases)
   - [Edge WebDriver](https://developer.microsoft.com/microsoft-edge/tools/webdriver/)

   Place WebDriver executables in your system PATH or project root.

4. Run tests:
```bash
dotnet test
```

## 📝 Logging

Test execution logs are available in the `Logs/` directory.

## 🌱 Design Patterns and Best Practices

- Page Object Model (POM)
- Behavior Driven Development (BDD) with SpecFlow
- Clear, maintainable, and readable code

## 🎯 Possible Improvements

- Introduce additional design patterns (e.g., Factory, Builder, Decorator)
- Implement configuration files (e.g., appsettings.json)
- Dockerization of test runs

---
