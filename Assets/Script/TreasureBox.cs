using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    private Animator animator;
    private bool canOpen;
    private bool isOpened;
    public Coin coin;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        canOpen = false;
        isOpened = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpened && canOpen && GameManager.isInteract)
        {
            animator.SetBool("Opened", true);
            isOpened = true;
            Invoke("BoxCoin",1.01f);
            GameManager.isInteract = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            canOpen = false;

        }
    }
    public  void BoxCoin() => Instantiate(coin,transform.position,Quaternion.identity);
    
}
