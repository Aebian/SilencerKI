/*
 *	Developed By: Aebian
 *	Name: SilencerKI
 *	Dependent: Rage Plugin Hook
 *	Released On: GitHub
 */


namespace SilencerKI.Utils
{
    using System;
    using System.ComponentModel;
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

            string AttachKey, AttachKeyModifier, AttachSilencerController, AttachSilencerControllerModifier;


            AttachKey = settings.ReadString("Keybinds", "AttachSilencer", "F10");
            AttachKeyModifier = settings.ReadString("Keybinds", "AttachSilencerModifier", "LShiftKey");

            AttachSilencerController = settings.ReadString("Keybinds", "AttachSilencerController", "DPadRight");
            AttachSilencerControllerModifier = settings.ReadString("Keybinds", "AttachSilencerControllerModifier", "LShiftKey");

            Global.Controls.AttachSilencer = (Keys)KeyCV.ConvertFromString(AttachKey);
            Global.Controls.AttachSilencerModifier = (Keys)KeyCV.ConvertFromString(AttachKeyModifier);


            TypeConverter typeConverter = TypeDescriptor.GetConverter(Global.Controls.AttachSilencerController);
            ControllerButtons CVController = (ControllerButtons)typeConverter.ConvertFromString(AttachSilencerController);
            ControllerButtons CVControllerModifier = (ControllerButtons)typeConverter.ConvertFromString(AttachSilencerControllerModifier);

            Global.Controls.AttachSilencerController = CVController;
            Global.Controls.AttachSilencerControllerModifier = CVControllerModifier;

            Logger.DebugLog("General Config Loading Finished."); 
        }
    }
}