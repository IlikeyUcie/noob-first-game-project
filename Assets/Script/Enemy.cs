using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract float health { get; set; }
    public abstract float damage { get; set; }
    public float flashTime;
    public GameObject coin;
    public GameObject floatPoint;
    private SpriteRenderer _sr;
    private Color _color;
    public GameObject bloodEffect;
    public TextMesh textMesh;
    private PlayerHealth _playerHealth;
    public void Awake()
    {
        flashTime = 0.2f;
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _color = _sr.color;
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Start()
    {

    }
    public void Update()
    {
        EnemyDestory();
    }

    public void TakeDamage(float damage)
    {
        CameraController.CameraShake();
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        textMesh.text = damage.ToString();
        Instantiate(floatPoint,transform.position,Quaternion.identity);
    }
    public void EnemyDestory()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(coin,transform.position,Quaternion.identity);
        } 
    }
    public void FlashColor(float time)
    {
        _sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    public void ResetColor()
    {
        _sr.color = _color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (other is PolygonCollider2D))
        {
            _playerHealth.PlayerTakeDamage(damage);
            _playerHealth.StartCoroutine(_playerHealth.CantTakeDamage());
        }
    }
}