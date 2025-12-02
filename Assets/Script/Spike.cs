using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();


    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is PolygonCollider2D)
        {
            _playerHealth.PlayerTakeDamage(damage);
            StartCoroutine(_playerHealth.CantTakeDamage());
        }
    }

}
