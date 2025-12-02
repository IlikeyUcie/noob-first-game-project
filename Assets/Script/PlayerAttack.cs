using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    private PolygonCollider2D attackCollider;
    public GameObject arrow;
    public GameObject sickle;

    // Start is called before the first frame update
    private void Awake()
    {
        attackCollider = GetComponent<PolygonCollider2D>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isArrowAttack)
        {

            StartCoroutine(Instantiate(arrow, transform.position, transform.parent.rotation).GetComponent<Arrow>().FlyTime());
        }
        GameManager.isArrowAttack = false;
        SickleAttack();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="magicNumber">当magicNumber为1时使攻击触发器出现，当magicNember为0时使攻击触发器消失</param>
    public void AttackEvent(int magicNumber)
    {
        if (magicNumber == 1)
        {
            attackCollider.enabled = true;
        }
        else
        {
            attackCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log($"EnemyHealth : {other.GetComponent<Enemy>().health}");
        }

    }
    void SickleAttack()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Instantiate(sickle, transform.position, Quaternion.identity);
    }

}
