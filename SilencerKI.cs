/*
 *	Developed By: Aebian
 *	Name: SilencerKI
 *	Dependent: Rage Plugin Hook
 *	Released On: GitHub
 */

[assembly: Rage.Attributes.Plugin("SilencerKI", Author = "Aebian", Description = "Attach Silencers to any weapon with ease", SupportUrl = "https://Aebian.org")]

namespace SilencerKI {
    using Rage;
	using SilencerKI.Utils;

    public static class EntryPoint
    {

        private static void StartPlugin()
        {
            GameFiber.StartNew(delegate { Core.RunPlugin(); });
        }

        public static void Main() {
            Global.Application.ConfigPath = "Plugins/";
            Global.Application.CurrentVersion = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";

			int versionStatus = Updater.CheckUpdate();
			if (versionStatus == -1) {
				Notifier.Notify("Plugin is out of date! (Current Version: ~r~" + Global.Application.CurrentVersion + " ~s~) - (Latest Version: ~g~" + Global.Application.LatestVersion + "~s~) Please update the plugin!");
				Logger.Log("Plugin is out of date. (Current Version: " + Global.Application.CurrentVersion + ") - (Latest Version: " + Global.Application.LatestVersion + ")");
			}
			else if(versionStatus == -2) {
				Logger.Log("There was an issue checking plugin versions, the plugin may be out of date!");
			}
			else if (versionStatus == 1) {
				Logger.Log("Current version of plugin is higher than the version reported, this could be an error that you may want to report!");
			}
			else {
				Notifier.Notify("Plugin loaded ~g~successfully~s~!");
				Logger.Log("Plugin Version v" + Global.Application.CurrentVersion + " loaded successfully");
			}

			//Loading general config
			Config.LoadConfig();

			StartPlugin();
		}
	}
}
