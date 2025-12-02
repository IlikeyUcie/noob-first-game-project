using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public static string password;
    public string realPassword;
    public GameObject coin;
    public float speed;
    public float intervalTime;
    public int coinQuantity;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (password == realPassword)
        {
            StartCoroutine(CoinAppearing());
            password = "";
        }
    }
    IEnumerator CoinAppearing()
    {
        for (int i = 0; i < coinQuantity; i++)
        {
            GameObject coinClone = Instantiate(coin, transform.position, Quaternion.identity);
            coinClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.3f, 0.3f), 1) * speed;
            yield return new WaitForSeconds(intervalTime);

        }
    }
}
