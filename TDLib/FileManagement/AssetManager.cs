using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BepInEx;
using UnityEngine;

namespace TDLib.FileManagement {
    /// <summary>
    /// Several utilities for loading files.
    /// </summary>
	public class AssetManager {

        /// <summary>
        /// Creates a new <see cref="AssetManager"/> using the provided plugin.
        /// </summary>
        /// <param name="plugin">The plugin that this instance is associated with.</param>
		public AssetManager(PluginInfo plugin) {
            MainPlugin.logger.LogDebug($"Mod is null: {plugin == null}");
            MainPlugin.logger.LogDebug($"Mod path: {plugin.Location}");
            MainPlugin.logger.LogDebug($"Mod name: {plugin.Metadata.Name}");
            string path = plugin.Location.Replace($"{plugin.Metadata.Name}.dll", "");
			MainPlugin.logger.LogDebug($"Root directory for mod {plugin.Metadata.Name} is {path}");
			RootDir = path;
		}

        /// <summary>
        /// Creates a new <see cref="AssetManager"/> using a manually specified asset folder location.
        /// </summary>
        /// <param name="RootDir">Directory to the assets folder.</param>
		public AssetManager(string RootDir) {
			this.RootDir = RootDir;
		}

        /// <summary>
        /// Location of the assets folder for this instance.
        /// </summary>
		public string RootDir = "";

        /// <summary>
        /// Returns the path for a file in the assets folder.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="extension">The extension of the file.</param>
        /// <returns></returns>
        public string PathFor(string name, string extension) {
            return Path.Combine(RootDir, "assets", name) + $".{extension}";
        }

        /// <summary>
        /// Loads a PNG file from the assets folder. <seealso href="https://answers.unity.com/questions/432655/loading-texture-file-from-pngjpg-file-on-disk.html"/>
        /// </summary>
        /// <param name="name">The name of the image, not including the path to the assets folder and the extension.</param>
        /// <returns>The image, as a Texture2D.</returns>
        public Texture2D LoadPNG(string name) {
            string path = PathFor(name,"png");
            return LoadPNGPath(path);
        }

        /// <summary>
        /// Loads a PNG file from disk. <seealso href="https://answers.unity.com/questions/432655/loading-texture-file-from-pngjpg-file-on-disk.html"/>
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <returns>The image, as a Texture2D.</returns>
        public Texture2D LoadPNGPath(string path) {
            MainPlugin.logger.LogInfo($"Loading texture {path}");

            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(path)) {
                fileData = File.ReadAllBytes(path);
                tex = new Texture2D(2, 2, TextureFormat.BGRA32, false);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                tex.filterMode = FilterMode.Point;
            } else {
                MainPlugin.logger.LogWarning($"Texture {path} does not exist!");
            }
            return tex;
        }

        /// <summary>
        /// Loads a TXT file from disk.
        /// </summary>
        /// <param name="name">The path to the file.</param>
        /// <returns>The text, as a <see cref="String"/>.</returns>
        public string LoadTXT(string name) {
            return File.ReadAllText(PathFor(name, "txt"));
        }

        /// <summary>
        /// Loads a CSV file from disk.
        /// </summary>
        /// <param name="name">The path to the file.</param>
        /// <returns>The text, as a <see cref="String"/>.</returns>
        public string[] LoadCSV(string name) {
            return Regex.Split(File.ReadAllText(PathFor(name, "csv")),@",\s*");
        }
        /*
        /// <summary>
        /// Loads an asset bundle from disk.
        /// </summary>
        /// <param name="name">The name of the asset bundle, not including the path to the assets folder and the extension.</param>
        /// <returns>The Asset Bundle.</returns>
        public AssetBundle LoadAssetBundle(string name) {
            return AssetBundle.LoadFromFile(PathFor(name, ""));
        }
        */
    }

}
