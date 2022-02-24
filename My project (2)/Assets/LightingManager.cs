using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways] //this executes certain methods in this class while we are in the editor (good for screen shots/testing lighting during editor)
public class LightingManager : MonoBehaviour
{
    //references
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //variable for the time of day
    [SerializeField, Range(0, 18)] private float TimeODay;

    private void UpdateLighting(float time) //this will change the lighting dependant on the time of day

    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(time); //rendering our variables
        RenderSettings.fogColor = Preset.FogColor.Evaluate(time);

        if (DirectionalLight != null) //setting up our directional light
        {

            DirectionalLight.color = Preset.DirectionalColor.Evaluate(time);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 170, 0)); //the 0 here can be changed to change rotation of directionallight

        }
    }

    private void OnValidate() //this will be called everytime we reload the script
    {

        if (DirectionalLight != null) //this triggers if we do not have a sun refernce
        {
            return;
        }

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }

        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>(); //varaible for directional light in scene
            foreach (Light light in lights) //this will find the first directional light in the scene
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    void Update() //now we want to actually impement everything in an update method
    {
        if (Preset == null) //check if we have a preset
        {
            return;
        }

        if (Application.isPlaying)
        {
            TimeODay += Time.deltaTime*2;
            TimeODay %= 9; //resets time when necessary
            UpdateLighting(TimeODay / 12f);

        }

        else
        {
            UpdateLighting(TimeODay / 12f);
        }
    }
}
