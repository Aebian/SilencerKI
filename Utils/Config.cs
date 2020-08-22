/*
 *	Developed By: Aebian
 *	Name: SilencerKI
 *	Dependent: Rage Plugin Hook
 *	Released On: GitHub
 */


namespace SilencerKI.Utils
{
    using System.Windows.Forms;
    using Rage;

    internal static class Config
    {
        private static InitializationFile initialiseFile(string filepath)
        {
            InitializationFile ini = new InitializationFile(filepath);
            ini.Create();
            return ini;
        }

        public static void LoadConfig()
        {
            InitializationFile settings = initialiseFile(Global.Application.ConfigPath + "SilencerKI.ini");
            Logger.DebugLog("General Config Loading Started.");

            Global.Application.DebugLogging = (settings.ReadBoolean("General", "DebugLogging", false));
            KeysConverter KeyCV = new KeysConverter();

            string AttachKey, AttachKeyModifier;

            AttachKey = settings.ReadString("Keybinds", "AttachSilencer", "F10");
            AttachKeyModifier = settings.ReadString("Keybinds", "AttachSilencerModifier", "LShiftKey");

            Global.Controls.AttachSilencer = (Keys)KeyCV.ConvertFromString(AttachKey);
            Global.Controls.AttachSilencerModifier = (Keys)KeyCV.ConvertFromString(AttachKeyModifier);

            Logger.DebugLog("General Config Loading Finished.");
        }
    }
}