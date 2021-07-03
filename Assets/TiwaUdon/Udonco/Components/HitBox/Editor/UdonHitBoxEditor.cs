
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEditor;
using UnityEngine;

#if !COMPILER_UDONSHARP && UNITY_EDITOR // These using statements must be wrapped in this check to prevent issues on builds
using UnityEditor;
using UdonSharpEditor;
#endif

namespace TiwaUdon.Udonco.HitBox.Editor
{
#if !COMPILER_UDONSHARP && UNITY_EDITOR
    [CustomEditor(typeof(HitBox))]
    public class UdonHitBoxEditor : UnityEditor.Editor
    {
        private HitBox hitBox;

        private Vector3 newAposition;
        private Vector3 newBposition;
        private Vector3 newCposition;
        private Vector3 newDposition;
        
        public override void OnInspectorGUI()
        {
            // Draws the default convert to UdonBehaviour button, program asset field, sync settings, etc.
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;

            hitBox = (HitBox) target;

            hitBox.isTargetLocalPlayer = EditorGUILayout.Toggle("is Local Player", hitBox.isTargetLocalPlayer);

            EditorGUI.BeginDisabledGroup(hitBox.isTargetLocalPlayer);
            hitBox.targetObject =
                EditorGUILayout.ObjectField("Target", hitBox.targetObject, typeof(Transform)) as Transform;
            EditorGUI.EndDisabledGroup();

            hitBox.pointA =
                EditorGUILayout.ObjectField("PointA", hitBox.pointA, typeof(Transform)) as Transform;
            hitBox.pointB =
                EditorGUILayout.ObjectField("PointB", hitBox.pointB, typeof(Transform)) as Transform;
            hitBox.pointC =
                EditorGUILayout.ObjectField("PointC", hitBox.pointC, typeof(Transform)) as Transform;
            hitBox.pointD =
                EditorGUILayout.ObjectField("PointD", hitBox.pointD, typeof(Transform)) as Transform;

            hitBox.height = EditorGUILayout.FloatField("Height", hitBox.height);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Area Point");

            EditorGUI.BeginDisabledGroup(hitBox.pointA == null);
            newAposition = EditorGUILayout.Vector3Field("A", (hitBox.pointA ?? hitBox.transform).localPosition);
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(hitBox.pointB == null);
            newBposition = EditorGUILayout.Vector3Field("B", (hitBox.pointB ?? hitBox.transform).localPosition);
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(hitBox.pointC == null);
            newCposition = EditorGUILayout.Vector3Field("C", (hitBox.pointC ?? hitBox.transform).localPosition);
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(hitBox.pointD == null);
            newDposition = EditorGUILayout.Vector3Field("D", (hitBox.pointD ?? hitBox.transform).localPosition);
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.Toggle("is Stay Target", hitBox.isStayTarget);

            if (hitBox.pointA != null)
                hitBox.pointA.localPosition = newAposition;
            if (hitBox.pointB != null)
                hitBox.pointB.localPosition = newBposition;
            if (hitBox.pointC != null)
                hitBox.pointC.localPosition = newCposition;
            if (hitBox.pointD != null)
                hitBox.pointD.localPosition = newDposition;
        }

        private void OnSceneGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 20;
            style.normal.textColor = Color.white;

            var labelAPosition = hitBox ? hitBox.transform.position : Vector3.zero;
            var labelBPosition = hitBox ? hitBox.transform.position : Vector3.zero;
            var labelCPosition = hitBox ? hitBox.transform.position : Vector3.zero;
            var labelDPosition = hitBox ? hitBox.transform.position : Vector3.zero;

            if (hitBox.pointA != null)
            {
                labelAPosition = hitBox.pointA.position;
                UnityEditor.Handles.Label(labelAPosition, "A", style);
            }

            if (hitBox.pointB != null)
            {
                labelBPosition = hitBox.pointB.position;
                UnityEditor.Handles.Label(labelBPosition, "B", style);
            }

            if (hitBox.pointC != null)
            {
                labelCPosition = hitBox.pointC.position;
                UnityEditor.Handles.Label(labelCPosition, "C", style);
            }

            if (hitBox.pointD != null)
            {
                labelDPosition = hitBox.pointD.position;
                UnityEditor.Handles.Label(labelDPosition, "D", style);
            }

            var topAPosition = labelAPosition + hitBox.transform.up * hitBox.height;
            var topBPosition = labelBPosition + hitBox.transform.up * hitBox.height;
            var topCPosition = labelCPosition + hitBox.transform.up * hitBox.height;
            var topDPosition = labelDPosition + hitBox.transform.up * hitBox.height;
            
            Handles.color = Color.yellow;
            DrawLine(labelAPosition, labelBPosition);
            DrawLine(labelBPosition, labelCPosition);
            DrawLine(labelCPosition, labelDPosition);
            DrawLine(labelDPosition, labelAPosition);

            DrawLine(topAPosition, topBPosition);
            DrawLine(topBPosition, topCPosition);
            DrawLine(topCPosition, topDPosition);
            DrawLine(topDPosition, topAPosition);

            DrawLine(labelAPosition, topAPosition);
            DrawLine(labelBPosition, topBPosition);
            DrawLine(labelCPosition, topCPosition);
            DrawLine(labelDPosition, topDPosition);

            Vector3 HitBoxRF = Vector3.zero;
            Vector3 HitBoxLB = Vector3.zero;;
            
            HitBoxRF.x = GetMax4(labelAPosition.x, labelBPosition.x, labelCPosition.x, labelDPosition.x);
            HitBoxRF.z = GetMax4(labelAPosition.z, labelBPosition.z, labelCPosition.z, labelDPosition.z);
            HitBoxLB.x = GetMin4(labelAPosition.x, labelBPosition.x, labelCPosition.x, labelDPosition.x);
            HitBoxLB.z = GetMin4(labelAPosition.z, labelBPosition.z, labelCPosition.z, labelDPosition.z);
            
            var realPositionA = new Vector3(HitBoxRF.x, 0, HitBoxRF.z);
            var realPositionB = new Vector3(HitBoxLB.x, 0, HitBoxRF.z);
            var realPositionC = new Vector3(HitBoxLB.x, 0, HitBoxLB.z);
            var realPositionD = new Vector3(HitBoxRF.x, 0, HitBoxLB.z);
            
            var realTopPositionA = realPositionA + Vector3.up * hitBox.height;
            var realTopPositionB = realPositionB + Vector3.up * hitBox.height;
            var realTopPositionC = realPositionC + Vector3.up * hitBox.height;
            var realTopPositionD = realPositionD + Vector3.up * hitBox.height;
            
            Handles.color = Color.green;
            DrawLine(realPositionA, realPositionB);
            DrawLine(realPositionB, realPositionC);
            DrawLine(realPositionC, realPositionD);
            DrawLine(realPositionD, realPositionA);

            DrawLine(realTopPositionA, realTopPositionB);
            DrawLine(realTopPositionB, realTopPositionC);
            DrawLine(realTopPositionC, realTopPositionD);
            DrawLine(realTopPositionD, realTopPositionA);

            DrawLine(realPositionA, realTopPositionA);
            DrawLine(realPositionB, realTopPositionB);
            DrawLine(realPositionC, realTopPositionC);
            DrawLine(realPositionD, realTopPositionD);
        }

        void DrawLine(Vector3 start, Vector3 end)
        {
            Handles.DrawLine(start, end);
        }
        
        float GetMax4(float f1, float f2, float f3, float f4)
        {
            return Mathf.Max(f4, Mathf.Max(f3, Mathf.Max(f1, f2)));
        }

        float GetMin4(float f1, float f2, float f3, float f4)
        {
            return Mathf.Min(f4, Mathf.Min(f3, Mathf.Min(f1, f2)));
        }
    }
}
#endif
