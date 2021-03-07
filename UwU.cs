using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using I2.Loc;
using System;
using System.Reflection;
using UnityEngine;

namespace UwU_Mod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    //[BepInDependency(PolyTechFramework.PolyTechMain.pluginGuid, BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Poly Bridge 2.exe")]
    public class PluginMain : BaseUnityPlugin
    {
        [Header("Hello decompiler!")]
        public const String PluginGuid = "polytech.uwu_mod";
        public const String PluginName = "UwU Mod";
        public const String PluginVersion = "1.0.1";

        public static ConfigEntry<bool> ModIsEnabled;

        Harmony harmony;
        void Awake()
        {
            ModIsEnabled = Config.Bind("͔General", "OwO UwU", true, new ConfigDescription("uwu", null, new ConfigurationManagerAttributes { Order = 4 }));

            harmony = new Harmony(PluginGuid);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        //void Update() {}

        [HarmonyPatch(typeof(LocalizationManager), "GetTranslation")]
        public class Patch
        {
            [HarmonyPostfix]
            private static void Postfix(ref string __result)
            {
                bool flag = __result == null || !PluginMain.ModIsEnabled.Value;
                if (!flag)
                {
                    string text = __result;
                    __result = text.Replace("r", "w").Replace("R", "W").Replace("l", "w").Replace("L", "W");
                }
            }
        }
    }
}
