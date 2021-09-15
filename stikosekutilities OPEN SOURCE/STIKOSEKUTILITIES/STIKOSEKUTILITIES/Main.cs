﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace STIKOSEKUTILITIES
{
    
        [BepInPlugin(GUID, MODNAME, VERSION)]
        public class Main : BaseUnityPlugin
        {
            #region[Declarations]
            public const string
                MODNAME = "stikosekutilities",
                AUTHOR = "stikosek",
                GUID = AUTHOR + "_" + MODNAME,
                VERSION = "0.0.1.0";
            internal readonly ManualLogSource log;
            internal readonly Harmony harmony;
            internal readonly Assembly assembly;
            public readonly string modFolder;
            #endregion

            public Main()
            {
                log = Logger;
                harmony = new Harmony(GUID);
                assembly = Assembly.GetExecutingAssembly();
                modFolder = Path.GetDirectoryName(assembly.Location);
            }
            private static GameObject Load;
            

        public void Start()
            {
                harmony.PatchAll(assembly);
                Load = new GameObject();
               
                Load.AddComponent<GUIscript.GUISys>();
                Load.AddComponent<ESPscript.ESPhacks>();
                UnityEngine.Object.DontDestroyOnLoad(Load);
                
        
        }

        }

    
}
