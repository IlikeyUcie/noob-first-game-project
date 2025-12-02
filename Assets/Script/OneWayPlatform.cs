using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public PlayerController playerController;
    private bool _isOneWayPlatform;
    private new CompositeCollider2D collider2D;
    private void Awake()
    {
        collider2D = GetComponent<CompositeCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlatformController();
    }
    void PlatformController()
    {
        if(playerController != null)
        _isOneWayPlatform = playerController._myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        if (Input.GetKey(KeyCode.S) && _isOneWayPlatform)
        {
            collider2D.isTrigger = true;
       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            collider2D.isTrigger = false;
        }
    }
}
