using MelonLoader;
using HarmonyLib;
using UnityEngine;

[assembly: MelonInfo(typeof(speeedLab.Core), "speeedLab", "1.0.0", "freakycheesy", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace speeedLab {
    [HarmonyPatch]
    public class Core : MelonMod {
        public override void OnInitializeMelon() {
            LoggerInstance.Msg("Initialized.");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            RenderSettings.fog = false;
            RenderSettings.customReflection = null;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.antiAliasing = 0;
            QualitySettings.billboardsFaceCameraPosition = false;
            QualitySettings.currentLevel = QualityLevel.Fastest;
            QualitySettings.lodBias = 0;
            QualitySettings.maximumLODLevel = 2;
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