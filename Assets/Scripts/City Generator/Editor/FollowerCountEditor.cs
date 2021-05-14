using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FollowerCount))]
public class FollowerCountEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FollowerCount followerCount = (FollowerCount)target;
        EditorGUILayout.HelpBox(followerCount.HelpText, MessageType.Warning);
    }
}
