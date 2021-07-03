using System.Collections;
using System.Collections.Generic;
using System.IO;
using UdonSharp;
using UnityEditor;
using UnityEngine;

/*
 * Copyright (c) 2020 Merlin
 * Released under the MIT license
 * https://github.com/MerlinVR/UdonSharp/blob/master/LICENSE
 * OR
 * TiwaUdon\Assets\TiwaUdon\Udon\Udonco\Core\Scripts\Editor\LICENSE.txt"
 */

namespace TiwaUdon.Editor
{
    public class UdoncoTemplateHelper : MonoBehaviour
    {
        public static void CreateUSharpScript(string templateTextAssetPath)
        {
            string folderPath = "Assets/";
            if (Selection.activeObject != null)
            {
                folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
                if (Selection.activeObject.GetType() != typeof(UnityEditor.DefaultAsset))
                {
                    folderPath = Path.GetDirectoryName(folderPath);
                }
            }
            else if (Selection.assetGUIDs.Length > 0)
            {
                folderPath = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
            }

            folderPath = folderPath.Replace('\\', '/');

            string chosenFilePath =
                EditorUtility.SaveFilePanelInProject("Save UdonSharp File", "", "cs", "Save UdonSharp file",
                    folderPath);

            if (chosenFilePath.Length > 0)
            {
                chosenFilePath = UdoncoTemplateHelper.SanitizeScriptFilePath(chosenFilePath);
                string chosenFileName =
                    Path.GetFileNameWithoutExtension(chosenFilePath).Replace(" ", "").Replace("#", "Sharp");
                string assetFilePath = Path.Combine(Path.GetDirectoryName(chosenFilePath), $"{chosenFileName}.asset");

                if (AssetDatabase.LoadAssetAtPath<UdonSharpProgramAsset>(assetFilePath) != null)
                {
                    if (!EditorUtility.DisplayDialog("File already exists",
                        $"Corresponding asset file '{assetFilePath}' already found for new UdonSharp script. Overwrite?",
                        "Ok", "Cancel"))
                        return;
                }

                var templete = AssetDatabase.LoadAssetAtPath<TextAsset>(templateTextAssetPath);
                if (templete == null)
                {
                    Debug.LogError("templete not found");
                    return;
                }

                string fileContents = templete.text.Replace("<TemplateClassName>", chosenFileName);
                ;

                File.WriteAllText(chosenFilePath, fileContents, System.Text.Encoding.UTF8);

                AssetDatabase.ImportAsset(chosenFilePath, ImportAssetOptions.ForceSynchronousImport);
                MonoScript newScript = AssetDatabase.LoadAssetAtPath<MonoScript>(chosenFilePath);

                UdonSharpProgramAsset newProgramAsset = ScriptableObject.CreateInstance<UdonSharpProgramAsset>();
                newProgramAsset.sourceCsScript = newScript;

                AssetDatabase.CreateAsset(newProgramAsset, assetFilePath);

                AssetDatabase.Refresh();
            }
        }

        public static string SanitizeName(string name)
        {
            return name.Replace(" ", "")
                .Replace("#", "Sharp")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("*", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("-", "_")
                .Replace("!", "")
                .Replace("$", "")
                .Replace("@", "")
                .Replace("+", "");
        }

        public static string SanitizeScriptFilePath(string file)
        {
            string fileName = SanitizeName(Path.GetFileNameWithoutExtension(file));
            string filePath = Path.GetDirectoryName(file);

            return $"{filePath}/{fileName}{Path.GetExtension(file)}";
        }
    }
}