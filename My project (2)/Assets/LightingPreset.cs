using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]

public class LightingPreset : ScriptableObject //this scriptableobject enables us to share presets between scenes by creating a file, "Lighting Preset" will be this file
{

    //these variables easily allow us to change color in the inspecter on unity
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor; //could use a fog intensity

}
