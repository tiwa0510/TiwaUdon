using System.Collections;
using System.Collections.Generic;
using System.IO;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace TiwaUdon.Editor
{
    [CustomEditor(typeof(UdonSharpBehaviour), true)]
    public class CreateUdoncoTemplateUdonSharpScript : UnityEditor.Editor
    {
        private static string templateTextAssetPath = @"Assets/TiwaUdon/Udonco/Core/Scripts/Editor/CutomEventInterfaceTemplate.txt";
        
        [MenuItem("Assets/Create/Udonco Command U# Script", false, 5)]
        private static void CreateUSharpScript()
        {
            UdoncoTemplateHelper.CreateUSharpScript(templateTextAssetPath);
        }
    }
}