using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TiwaUdon.Editor
{
    public class CreateUdoncoEventTriggerUdonSharpScript : MonoBehaviour
    {
        private static string templateTextAssetPath = @"Assets/TiwaUdon/Udonco/Core/Scripts/Editor/EventTriggerInterfaceTemplate.txt";

        [MenuItem("Assets/Create/Udonco EventTrigger U# Script", false, 4)]
        private static void CreateUSharpScript()
        {
            UdoncoTemplateHelper.CreateUSharpScript(templateTextAssetPath);
        }
    }
}
