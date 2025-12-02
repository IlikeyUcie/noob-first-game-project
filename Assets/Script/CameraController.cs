using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraController 
{
    public static void CameraShake()
    {
            Camera.main.GetComponent<Animator>().SetTrigger("CameraShake");
    }

}
