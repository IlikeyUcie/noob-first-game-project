using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] transforms;
    private int i;//Êý×éµÄÐòºÅ¡£
    public float speed;
    public float waitTime;
    private float _time;
    private Transform _playerTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        i = 1;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
        _time = waitTime;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transforms[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, transforms[i].position) < Mathf.Epsilon)
        {
            if (waitTime < 0)
            {
                i = 1 - i;
                waitTime = _time;
                //Debug.Log(i);
            }
            else
            { waitTime -= Time.deltaTime;
                //Debug.Log("yes");
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&other is BoxCollider2D)
            other.gameObject.transform.parent = gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is BoxCollider2D)
            collision.gameObject.transform.parent = null;
    }
}
