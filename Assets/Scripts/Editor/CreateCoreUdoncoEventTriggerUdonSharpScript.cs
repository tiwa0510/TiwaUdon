using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TiwaUdon.Editor
{
    public class CreateCoreUdoncoEventTriggerUdonSharpScript : MonoBehaviour
    {
        private static string templateTextAssetPath = @"Assets/TiwaUdon/Scripts/Editor/EventTriggerInterfaceTemplate.txt";

        //[MenuItem("Assets/Create/Core Udonco EventTrigger U# Script", false, 4)]
        private static void CreateUSharpScript()
        {
            UdoncoTemplateHelper.CreateUSharpScript(templateTextAssetPath);
        }
    }
}
