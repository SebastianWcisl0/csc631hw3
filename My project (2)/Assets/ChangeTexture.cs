using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    Texture[] textures;

    private void Awake()
    {
        Debug.Log($"LOADING TEXTURES");
        textures = Resources.LoadAll<Texture>("Textures");
        Debug.Log(textures.Length);

    }


    public void ButtonClick()
    {
        Debug.Log("CLICKED BITCHES");
        if (gameObject.GetComponent<Renderer>().material.mainTexture == null)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = textures[0];
        }


        var currentTexture = gameObject.GetComponent<Renderer>().material.mainTexture;

        switch (currentTexture.name)
        {

            case "One":
                gameObject.GetComponent<Renderer>().material.mainTexture = textures[1];
                break;
            case "Two":
                gameObject.GetComponent<Renderer>().material.mainTexture = textures[0];
                break;
            case "Three":
                gameObject.GetComponent<Renderer>().material.mainTexture = textures[2];
                break;
        }
    }



}
