using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public int damage;
    public float tunner;//平滑回到角色y轴位置的平滑参数。

    private Vector2 startSpeed;
    private Transform sicklePos;
    private Transform _playerPos;
    private Rigidbody2D _sickleRigidbody;
    private void Awake()
    {
        sicklePos = GetComponent<Transform>();
        _sickleRigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _sickleRigidbody.velocity = (PlayerController.isFlip ? Vector2.left : Vector2.right) * speed;
        startSpeed = _sickleRigidbody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotationSpeed);
        float sickleY = Mathf.Lerp(transform.position.y, _playerPos.position.y, tunner);
        _sickleRigidbody.velocity -= startSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x,sickleY);
        //StartCoroutine(SelfDestory());

        if (Mathf.Abs(transform.position.x - _playerPos.position.x) < 0.5)
            Destroy(gameObject);
    }
    IEnumerator SelfDestory()
    {
        yield return new WaitForSeconds(1);
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<Enemy>().TakeDamage(damage);
    }
}
