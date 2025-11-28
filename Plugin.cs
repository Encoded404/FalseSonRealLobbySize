using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using RoR2;
using UnityEngine;

namespace FalseSonRealLobbySize
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "Encoded404.Encoded404.FalseSonRealLobbySize";
        public const string PluginName = "FalseSonRealLobbySize";
        public const string PluginVersion = "1.0.0";

        internal static ManualLogSource Log = null!;

        private ConfigEntry<float> cfg_displaySizeMulti;

        public void Awake()
        {
            Log = Logger;

            cfg_displaySizeMulti = Config.Bind<float>(
                "General",
                "CSS Size Multiplier",
                1f,
                "Multiplier for False Son's size on the character selection screen. Vanilla is 0.7 * his in-game size."
            );

            RoR2Application.onLoad += OnLoad;
            
            Log.LogInfo($"{PluginName} v{PluginVersion} loaded!");
        }

        private void OnLoad()
        {
            CharacterBody falseSonBody = BodyCatalog.FindBodyPrefab("FalseSonBody").GetComponent<CharacterBody>();
            SurvivorDef survivorDef = SurvivorCatalog.FindSurvivorDefFromBody(falseSonBody.gameObject);
            
            survivorDef.displayPrefab.transform.GetChild(0).localScale = Vector3.one * cfg_displaySizeMulti.Value;
            
            Log.LogInfo($"False Son CSS display size set to {cfg_displaySizeMulti.Value}x");
        }
    }
}
