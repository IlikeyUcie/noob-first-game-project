using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public  int speed;
    private PlayerController _playerCon;
    public float time;
    private Rigidbody2D _rigidbody2D;
    public int damage;
    private Transform _gunTransform;
    private bool isDestory;

    // Start is called before the first frame update
    private void Awake()
    {
        
        _playerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //_gunTransform = GameObject.FindGameObjectWithTag("Gun").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator FlyTime()
    {
       
        yield return new WaitForSeconds(time);
        if (!isDestory)
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
            isDestory = true;
        }
    }
}
