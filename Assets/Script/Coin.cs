using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            CoinText._coinNumber += 1;
            Destroy(gameObject);
            AudioManager.GetCoin();
        }
    }
}
