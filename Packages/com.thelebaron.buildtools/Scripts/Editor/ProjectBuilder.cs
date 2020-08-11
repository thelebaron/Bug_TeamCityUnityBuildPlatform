﻿using System.Diagnostics;
using System.IO;
using thelebaron.BuildTools;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using Debug = UnityEngine.Debug;
using Directory = UnityEngine.Windows.Directory;
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Unity.Assertions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;

// ReSharper disable UnusedMember.Global

namespace Unity.Build
{
    public static class ProjectBuilder
    {
        [MenuItem("ProjectBuilder/Build(Latest git)")]
        public static void NewPipelineBuild()
        {
            
            Save();
            
            Versioning.ClearConsole();
            
            SemVer.BumpPatch();
            
            AddressableAssetSettings.BuildPlayerContent();
            
            LoadResourceFile();

            OpenBuildFolder();
        }

        public static void LoadResourceFile()
        {
            Debug.Log("Building project using new build pipeline");
            //PlayerSettings.bundleVersion = Git.BuildVersion;
            
            var buildSettings = (BuildConfiguration)AssetDatabase.LoadAssetAtPath("Packages/com.thelebaron.BuildTools/game.buildconfiguration", typeof(BuildConfiguration)); 
            
            Assert.IsNotNull(buildSettings);
            buildSettings.Build();
            
        }

        private static void Save()
        {
            AssetDatabase.SaveAssets();
            EditorSceneManager.SaveOpenScenes();
        }

        
        private static void OpenBuildFolder()
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "\\" + "Builds" + "\\" + "game";
            if (Directory.Exists(path))
            {
                var processStartInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName  = "explorer.exe"
                };

                Process.Start(processStartInfo);
            }
        }
        // Obsolete but for reference
        /*
         *

        
        [MenuItem("Build/(Obsolete)Windows Standalone")]
        static void Win64()
        {
            //string[] scenes = { "Assets/Scenes/prototypeScene3.unity" };
            //BuildPipeline.BuildPlayer(scenes, "StandaloneWindows64", BuildTarget.StandaloneWindows64, BuildOptions.None);
            
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes           = new[] {"Assets/Scenes/protoypeScene3.unity"}; //, "Assets/Scene2.unity"
            buildPlayerOptions.locationPathName = "F:/builds/il2cpp/cyber/cyber.exe";
            buildPlayerOptions.target           = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.options          = BuildOptions.ShowBuiltPlayer;
            UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);
            
        }

        [MenuItem("Build/(Obsolete)UWP")]
        public static void UWP()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes           = new[] {"Assets/Scenes/protoypeScene3.unity"}; //, "Assets/Scene2.unity"
            buildPlayerOptions.locationPathName = "F:/builds/uwp/cyber/cyber.exe";
            buildPlayerOptions.target           = BuildTarget.WSAPlayer;
            buildPlayerOptions.options          = BuildOptions.ShowBuiltPlayer;
            UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);


        }
         */
    }
}

#endif