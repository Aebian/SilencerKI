/*
 *	Developed By: Aebian
 *	Name: SilencerKI
 *	Dependent: Rage Plugin Hook
 *	Released On: GitHub
 */

namespace SilencerKI.Utils
{
    using System.Windows.Forms;
    using System.Collections.Generic;
    using Rage;
    using Rage.Native;

    internal static class Core
    {

        public static void RunPlugin()

        {

            Global.Dynamics.CurrentPed = Game.LocalPlayer.Character;

            Logger.DebugLog("Core Plugin Function Started");

            //Game loop
            while (true)
            {
                GameFiber.Yield();

                if ((Game.IsKeyDownRightNow(Global.Controls.AttachSilencerModifier) && Game.IsKeyDown(Global.Controls.AttachSilencer) || Global.Controls.AttachSilencerModifier == Keys.None && Game.IsKeyDown(Global.Controls.AttachSilencer)) && (Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject != null))
                {
                        UpdatePlayer();
                        if (NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0x837445AA) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xA73D4664) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xC304849A) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0x65EA7EBB) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xE608B35E) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xAC42DF71))
                        {
                            Logger.DebugLog("Trying to remove silencer from current selected weapon:");
                            Logger.DebugLog(Global.Dynamics.EquippedWeaponHash.ToString());
                            RemoveSilencer();
                        }
                        else
                        {
                            Logger.DebugLog("Trying to attach silencer to current selected weapon:");
                            Logger.DebugLog(Global.Dynamics.EquippedWeaponHash.ToString());
                            AttachSilencer();
                        }
                }
            }

        }

        private static void UpdatePlayer()
        {
            Global.Dynamics.CurrentPed = Game.LocalPlayer.Character;
            Global.Dynamics.EquippedWeaponHash = Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject.Model.Hash;
        }

        private static void AttachSilencer()
        {

            switch (Global.Dynamics.EquippedWeaponHash)
            {
                //COMPONENT_AT_AR_SUPP;
                case 2587382322: //WEAPON_ADVANCEDRIFLE
                case 1255410010: //WEAPON_ASSAULTSHOTGUN
                case 3006407723: //WEAPON_BULLPUPRIFLE
                case 1415744902: //WEAPON_BULLPUPRIFLE_MK2
                case 1026431720: //WEAPON_CARBINERIFLE
                case 1520780799: //WEAPON_CARBINERIFLE_MK2
                case 2583718658: //WEAPON_MARKSMANRIFLE
                case 2436666926: //WEAPON_MARKSMANRIFLE_MK2

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_AR_SUPP");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_AR_SUPP_02;
                case 273925117: //WEAPON_ASSAULTRIFLE:
                case 1762764713: //WEAPON_ASSAULTRIFLE_MK2:
                case 3821393119: //WEAPON_ASSAULTSMG:
                case 2696754462: //WEAPON_BULLPUPSHOTGUN:
                case 3085098415: //WEAPON_HEAVYSHOTGUN:
                case 4116483281: //WEAPON_PISTOL50:
                case 346403307: //WEAPON_SNIPERRIFLE:
                case 2549323539: //WEAPON_SPECIALCARBINE:
                case 2379721761: //WEAPON_SPECIALCARBINE_MK2:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_AR_SUPP_02");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_PI_SUPP;
                case 905830540: //WEAPON_APPISTOL:
                case 403140669: //WEAPON_COMBATPISTOL:
                case 1927398017: //WEAPON_HEAVYPISTOL:
                case 3963421467: //WEAPON_MACHINEPISTOL:
                case 3794909300: //WEAPON_SMG:
                case 2547423399: //WEAPON_SMG_MK2:
                case 3170921020: //WEAPON_VINTAGEPISTOL:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_PI_SUPP");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_PI_SUPP_02;
                case 1467525553: //WEAPON_PISTOL:
                case 995074671: //WEAPON_PISTOL_MK2:
                case 4221916961: //WEAPON_SNSPISTOL_MK2:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_PI_SUPP_02");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_SR_SUPP;
                case 689760839: //WEAPON_PUMPSHOTGUN:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_SR_SUPP");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_SR_SUPP_02;
                case 3238253642: //WEAPON_MICROSMG:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_SR_SUPP_02");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                //COMPONENT_AT_SR_SUPP_03;
                case 619715967: //WEAPON_HEAVYSNIPER_MK2:
                case 3194406291: //WEAPON_PUMPSHOTGUN_MK2:

                    Global.Dynamics.CurrentPed.Inventory.AddComponentToWeapon(Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Asset, "COMPONENT_AT_SR_SUPP_03");
                    Logger.DebugLog("Attached silencer to current selected weapon successfully.");
                    break;

                default:
                    Logger.DebugLog("Warning: Cannot determine silencer model of equipped weapon. Silencers only exist for specific firearms.");
                    break;
            }

        }

        private static void RemoveSilencer()
        {
            try
            {

                List<string> silencers = new List<string> { "COMPONENT_AT_AR_SUPP", "COMPONENT_AT_AR_SUPP_02", "COMPONENT_AT_PI_SUPP", "COMPONENT_AT_PI_SUPP_02", "COMPONENT_AT_SR_SUPP", "COMPONENT_AT_SR_SUPP_02", "COMPONENT_AT_SR_SUPP_03" };
                foreach (string silencer in silencers)
                {
                    if (NativeFunction.Natives.HAS_PED_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed, (uint)Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Hash, Game.GetHashKey(silencer)))
                    {
                         NativeFunction.Natives.REMOVE_WEAPON_COMPONENT_FROM_PED<bool>(Global.Dynamics.CurrentPed, (uint)Global.Dynamics.CurrentPed.Inventory.EquippedWeapon.Hash, Game.GetHashKey(silencer));
                    }
                }

            }
            finally
            {
                if (NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0x837445AA) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xA73D4664) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xC304849A) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0x65EA7EBB) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xE608B35E) || NativeFunction.Natives.HAS_WEAPON_GOT_WEAPON_COMPONENT<bool>(Global.Dynamics.CurrentPed.Inventory.EquippedWeaponObject, 0xAC42DF71))
                {
                    Logger.DebugLog("Warning: Cannot determine if a silencer is attached to equipped weapon.");
                } 
                else
                {
                    Logger.DebugLog("Removed silencer to current selected weapon successfully.");
                }

            }
        }
    }

}

