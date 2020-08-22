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

    internal static class Global
    {
        internal static class Application
        {
            public static string CurrentVersion { get; set; }
            public static string LatestVersion { get; set; }
            public static bool DebugLogging { get; set; }
            public static string ConfigPath { get; set; }
        }

        internal static class Controls
        {
            public static Keys AttachSilencer { get; set; }
            public static Keys AttachSilencerModifier { get; set; }
        }

        internal static class Dynamics
        {
            public static uint EquippedWeaponHash { get; set; }
            public static Ped CurrentPed { get; set; }
        }
    }
}
