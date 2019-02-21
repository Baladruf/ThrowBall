using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {

    [SerializeField] Material inverse;
    [SerializeField] Material sin;

    private bool isInverse = false;
    private bool isSin = false;

    public bool SetInverse { set { isInverse = value; } }
    public bool SetSinus { set { isSin = value; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isInverse = !isInverse;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            isSin = !isSin;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isInverse)
        {
            Graphics.Blit(source, destination, inverse);
        }
        else if (isSin)
        {
            Graphics.Blit(source, destination, sin);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
