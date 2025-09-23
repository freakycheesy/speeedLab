using MelonLoader;
using HarmonyLib;
using UnityEngine;
using BoneLib.BoneMenu;

[assembly: MelonInfo(typeof(speeedLab.Core), "speeedLab", "1.0.0", "freakycheesy", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace speeedLab {
    [HarmonyPatch]
    public class Core : MelonMod {
        MelonPreferences_Entry<bool> entry;
        MelonPreferences_Category category;

        public override void OnInitializeMelon() {
            try {
                LoggerInstance.Msg("Initialized.");
                HarmonyInstance.PatchAll();
            }
            catch (Exception e) {
                MelonLogger.Error(e);
            }
            MelonPrefs();
            BoneMenus();
        }

        private void BoneMenus() {
            Page page = Page.Root.CreatePage("speeedLab", Color.green);
            page.CreateBool("Enabled (Only works on restart)", Color.green, entry.Value, (a) => { entry.Value = a; });
        }

        private void MelonPrefs() {
            category = MelonPreferences.CreateCategory("speedlab");
            entry = category.CreateEntry("speedLab Enabled", true);
            MelonPreferences.Save();
            category.SaveToFile();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            if (entry == null)
                return;
            if (!entry.Value)
                return;
            RenderSettings.fog = false;
            RenderSettings.customReflection = null;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.antiAliasing = 0;
            QualitySettings.billboardsFaceCameraPosition = false;
            QualitySettings.lodBias = 0;
            QualitySettings.maximumLODLevel = 1;
            QualitySettings.pixelLightCount = 0;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.shadowmaskMode = ShadowmaskMode.Shadowmask;
            QualitySettings.shadowResolution = ShadowResolution.Low;
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.skinWeights = SkinWeights.OneBone;
            QualitySettings.softParticles = false;
            QualitySettings.softVegetation = false;
            QualitySettings.vSyncCount = 0;
            QualitySettings.particleRaycastBudget = 0;
            Physics.solverIterationCount /= 2;
            Physics.solverVelocityIterationCount /= 2;
            Physics.sleepThreshold = 0.04f;
            Physics.sleepVelocity = 0.04f;
            Physics.sleepAngularVelocity = 0.04f;
            AudioSettings.speakerMode = AudioSpeakerMode.Mono;
        }
    }
    
}