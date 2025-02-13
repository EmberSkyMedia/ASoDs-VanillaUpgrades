﻿using HarmonyLib;
using SFS.Achievements;
using SFS.UI;
using SFS.World;
using SFS.WorldBase;
using System;
using UnityEngine;

namespace VanillaUpgrades
{
    [HarmonyPatch(typeof(WorldTime), nameof(WorldTime.DecelerateTime))]
    public class TimeDecelerationPatch
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (WorldTime.main.timewarpIndex == 0)
            {
                TimeDecelMain.SlowTime();
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(WorldTime), nameof(WorldTime.AccelerateTime))]
    public class EndDeceleration
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (TimeDecelMain.timeDecelIndex > 0)
            {
                WorldTime.main.SetState(1, true, false);
                MsgDrawer.main.Log("Time restored to normal");
                TimeDecelMain.timeDecelIndex = 0;
                return false;
            }
            return true;
        }
    }

    public static class TimeDecelMain
    {
        public static int timeDecelIndex = 0;

        public static void SlowTime()
        {
            if (!(bool)Config.settings["allowTimeSlowdown"]) return;
            if (timeDecelIndex <= 5) timeDecelIndex++; else return;
            double speed;
            bool defaultMessage = true;

            switch (timeDecelIndex)
            {
                case 1:
                    speed = 0.75;
                    break;
                case 2:
                    speed = 0.5;
                    break;
                case 3:
                    speed = 0.25;
                    break;
                case 4:
                    speed = 0.1;
                    break;
                case 5:
                    speed = 0;
                    defaultMessage = false;
                    break;
                default: return;
            }

            WorldTime.main.SetState(speed, true, defaultMessage);
            if (!defaultMessage) MsgDrawer.main.Log("Time frozen");
        }
    }
    public class TimeManipulation : MonoBehaviour
    {
        public static void StopTimewarp(bool showmsg)
        {
            if (WorldTime.main.timewarpIndex == 0 && TimeDecelMain.timeDecelIndex == 0) return;

            WorldTime.main.timewarpIndex = 0;
            WorldTime.main.SetState(1, true, false);
            TimeDecelMain.timeDecelIndex = 0;
            if (showmsg)
            {
                MsgDrawer.main.Log("Time acceleration stopped");
            }

        }
    }
}
