using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(WaterFloat))]

public class WF_Inspector : Editor
{
    SerializedProperty MovingDistances,
    speed,
    WaveRotations,
    WaveRotationsSpeed,
    AxisOffsetSpeed;

    void OnEnable()
    {
        MovingDistances = serializedObject.FindProperty("MovingDistances");
        speed = serializedObject.FindProperty("speed");    
        WaveRotations = serializedObject.FindProperty("WaveRotations");
        WaveRotationsSpeed = serializedObject.FindProperty("WaveRotationsSpeed");
        AxisOffsetSpeed = serializedObject.FindProperty("AxisOffsetSpeed");
    }

    public override void OnInspectorGUI(){
        GUILayout.Box(Resources.Load("WF_Poster") as Texture, GUILayout.Width(400), GUILayout.Height(214));
        WaterFloat script = (WaterFloat)target;

        EditorGUILayout.HelpBox("If you like this asset please don't forget to leave a nice review. It helps alot.", MessageType.Info);
        EditorGUILayout.Space();

        //Moving Distances
        EditorGUILayout.PropertyField(MovingDistances, new GUIContent("Moving Distances", "The vectors that will affect the floating effect"));

        //speed
        EditorGUILayout.PropertyField(speed, new GUIContent("Speed", "The speed of the floating effect vectors"));

        //Wave Rotation
        EditorGUILayout.PropertyField(WaveRotations, new GUIContent("Wave Rotation", "The vectors that will give a rotating effect to the floating object"));

        //Wave Rotation Speed
        EditorGUILayout.PropertyField(WaveRotationsSpeed, new GUIContent("Wave Rotation Speed", "The speed of the rotation effect"));

        //Axis Offset Speed
        EditorGUILayout.PropertyField(AxisOffsetSpeed, new GUIContent("Axis Offset Speed", "If you want the floating object to move along a certain axis. An effect that can be used for an example: running along a river."));

        serializedObject.ApplyModifiedProperties();
    }
}
