﻿using HarmonyLib;
using SFS.World;

namespace VanillaUpgrades
{
    [HarmonyPatch(typeof(PlayerController), "CreateShakeEffect")]
    public class RemoveShake
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (!(bool)Config.settings["explosionShake"])
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }

    [HarmonyPatch(typeof(EffectManager), "CreateExplosion")]
    public class StopExplosions
    {
        [HarmonyPrefix]
        static bool Prefix()
        {
            if (!(bool)Config.settings["explosions"])
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(EffectManager), "CreatePartOverheatEffect")]
    public class StopEntryExplosions
    {
        [HarmonyPrefix]
        static bool Prefix()
        {
            if (!(bool)Config.settings["explosions"])
            {
                return true;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerController), "TrackPlayer")]
    public class StopShake
    {
        [HarmonyPrefix]
        static bool Prefix()
        {
            if (!(bool)Config.settings["shakeEffects"])
            {
                WorldView.main.SetViewLocation(PlayerController.main.player.Value.location.Value);
                return false;
            }
            return true;
        }
    }

}
