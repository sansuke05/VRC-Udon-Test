using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using UdonSharp;

[InitializeOnLoad]
public static class CompileButton
{
    static CompileButton()
    {
        ToolbarExtender.RightToolbarGUI.Add(OnRightToolbarGUI);
    }

    private static void OnRightToolbarGUI()
    {
        if (GUILayout.Button("Compile UdpnSharp"))
        {
            UdonSharpProgramAsset.CompileAllCsPrograms();
        }

        GUILayout.FlexibleSpace();
    }
}
