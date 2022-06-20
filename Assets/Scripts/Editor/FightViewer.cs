using System;
using UnityEditor;
using UnityEngine;

public class FightViewer : EditorWindow
{
    [MenuItem("Tools/FightViewer")]
    public static void OpenFightViewer() => GetWindow<FightViewer>();

    private void OnEnable() => Selection.selectionChanged += Repaint;
    private void OnDisable() => Selection.selectionChanged -= Repaint;

    private void OnGUI()
    {
        GUILayout.Label("This is the fight viewing tool.");
    }
}