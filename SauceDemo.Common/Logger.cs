using log4net;
using log4net.Config;

namespace SauceDemo.Common;

public static class Logger
{
    public static readonly ILog Log = LogManager.GetLogger(typeof(Logger));

    static Logger()
    {
        var configFilePath = Path.Combine(AppContext.BaseDirectory, "log4net.config");
        XmlConfigurator.Configure(new FileInfo(configFilePath));
    }
}