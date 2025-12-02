using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int speed;
    private PlayerController _playerCon;
    public float time;
    private Rigidbody2D _rigidbody2D;
    public int damage;
    

    // Start is called before the first frame update
    private void Awake()
    {
        _playerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator FlyTime()
    {
        _rigidbody2D.velocity = (PlayerController.isFlip? Vector2.left : Vector2.right )* speed;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
