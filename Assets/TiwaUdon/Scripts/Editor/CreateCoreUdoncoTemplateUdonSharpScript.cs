using System.Collections;
using System.Collections.Generic;
using System.IO;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace TiwaUdon.Editor
{
    [CustomEditor(typeof(UdonSharpBehaviour), true)]
    public class CreateCoreUdoncoTemplateUdonSharpScript : UnityEditor.Editor
    {
        private static string templateTextAssetPath = @"Assets/TiwaUdon/Scripts/Editor/CutomEventInterfaceTemplate.txt";
        
        [MenuItem("Assets/Create/U# Script TiwaUdon Command", false, 5)]
        private static void CreateUSharpScript()
        {
            UdoncoTemplateHelper.CreateUSharpScript(templateTextAssetPath);
        }
    }
}