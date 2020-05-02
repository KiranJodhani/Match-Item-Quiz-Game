using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class StartUp
{

#if UNITY_EDITOR
    static string keystoreName = "Assets/KEYSTORE/immerch.keystore";
    static string keyaliasName = "immerch";
    static string keystorePass = "immerch";
    static string keyaliasPass = "immerch";
    

    static StartUp()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        if (PlayerSettings.Android.keystoreName != keystoreName)
        {
            PlayerSettings.Android.keystoreName = keystoreName;
        }

        if (PlayerSettings.Android.keyaliasName != keyaliasName)
        {
            PlayerSettings.Android.keyaliasName = keyaliasName;
        }

        if (PlayerSettings.Android.keystorePass != keystorePass)
        {
            PlayerSettings.Android.keystorePass = keystorePass;
        }

        if (PlayerSettings.Android.keyaliasPass != keyaliasPass)
        {
            PlayerSettings.Android.keyaliasPass = keyaliasPass;
        }

    }

  
#endif
}
