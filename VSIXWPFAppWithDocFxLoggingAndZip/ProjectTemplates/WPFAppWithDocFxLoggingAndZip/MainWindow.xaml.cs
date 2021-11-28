using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace $safeprojectname$
{
    /// <summary>
    ///    Class MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>The factory.</value>
        public static ILoggerFactory Factory { get; set; }
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public static ILogger Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Window" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if !DEBUG
            DumpExtensions.DisableDumping();
#endif
            CreateAppLogger(AppName(), AppPath());
        }
        /// <summary>Applications the path.</summary>
        /// <returns>System.String.</returns>
        public static string AppPath() => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>Applications the name.</summary>
        /// <returns>System.String.</returns>
        public static string AppName() => Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
        /// <summary>Creates the application logger.</summary>
        /// <param name="logName">Name of the log.</param>
        /// <param name="logFolder">The log folder.</param>
        public void CreateAppLogger(string logName, string logFolder)
        {
            if (Logger is not null)
            {
                return;
            }
            Factory = new LoggerFactory()
            .AddFile(logName, logFolder);
            Logger = Factory.CreateLogger($"{logName}_{nameof($safeprojectname$)}");
            Logger.LogInformation(message: $"Information; Created Log File for {logName}.",
                includeLineInfo: true);
            Logger.LogWarning(message: $"Warning; Creating Log File for {logName}.",
                includeLineInfo: true);
            Logger.LogTrace(message: $"Trace; Created Log File for {logName}.",
                includeLineInfo: true);
            Logger.LogDebug(message: $"Debug; Created Log File for {logName}.",
                includeLineInfo: true);
            try
            {
                //Sample Logger showing Dump Feature, This feature requires the Visual Dump Extension to be installed so the Visual Dump window is available or you will get a timeout error.
                Logger.LogDebug(message: $"Debug; Throwing new Exception.", includeLineInfo: true);
                throw new Exception("Example Exception.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, message: $"Error; Creating Log File for {logName}.",
                    includeLineInfo: true,
                    includeStackTrace: true);
            }
        }

    }
}
