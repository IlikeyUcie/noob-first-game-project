using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager:MonoBehaviour
{
    public static bool isInteract;
    public static bool isEscape;
    public static bool isArrowAttack;
    private void Update()
    {
        isInteracting();
        isEscape |= Input.GetKeyDown(KeyCode.Escape);
        isArrowAttack |= Input.GetKeyDown(KeyCode.U);

    }
    void isInteracting()
    {
        isInteract = Input.GetKeyDown(KeyCode.E);
 
    }
}

