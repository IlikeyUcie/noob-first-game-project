using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform playerTransform;
    public Transform doortransform;
    private bool inDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inDoor && GameManager.isInteract)
        {
            playerTransform.position = doortransform.position;
            GameManager.isInteract = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            inDoor = false;

        }
    }
}
