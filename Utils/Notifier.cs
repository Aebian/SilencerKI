/*
 *	Developed By: Aebian
 *	Name: SilencerKI
 *	Dependent: Rage Plugin Hook
 *	Released On: GitHub
 */

namespace SilencerKI.Utils
{
    using Rage;
    internal static class Notifier
    {
        //Simple log line
        internal static void Notify(string body)
        {
            string notice = string.Format("~p~{0}~s~", body);
            Game.DisplayNotification(notice);
            Logger.DebugLog("Notification Sent.");
        }
    }
}