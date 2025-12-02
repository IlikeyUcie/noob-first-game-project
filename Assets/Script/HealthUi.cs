using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthUi : MonoBehaviour
{
    public TMP_Text healthText;
    private PlayerHealth _playerHealth;
    public int maxHealth;
    public Image currentHealth;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        currentHealth = GetComponent<Image>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        maxHealth = (int)_playerHealth.health;

    }
    // Update is called once per frame
    void Update()
    {
        if (_playerHealth.health < 0)
            _playerHealth.health = 0;
        currentHealth.fillAmount = _playerHealth.health / maxHealth;
        healthText.text = maxHealth + "/" + _playerHealth.health;
    }
}
