using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float bulinCount;
    public float bulinTime;
    private Renderer PlayerRenderer;
    private Animator _playerAnimator;
    private PlayerController _playerController;
    private Rigidbody2D _playerRigidbody2D;
    private ScreenFlash _screenFlash;
    private PolygonCollider2D _playerPgc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        PlayerRenderer = GetComponent<Renderer>();
        _playerAnimator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _screenFlash = GameObject.Find("ScreenFlash").GetComponent<ScreenFlash>();
        _playerPgc = GetComponent<PolygonCollider2D>();

    }
    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            _playerAnimator.SetTrigger("Die");
            _playerRigidbody2D.velocity = new Vector2(0, 0);
            _playerController.enabled = false;
        }
        BlinkPlayer();
        _screenFlash.Flash();
    }
    void BlinkPlayer() => StartCoroutine(Dobulin());

    public IEnumerator Dobulin()
    {
        for (int i = 0; i < bulinCount * 2; i++)
        {
            PlayerRenderer.enabled = !PlayerRenderer.enabled;
            yield return new WaitForSeconds(bulinTime);
        }
        PlayerRenderer.enabled = true;
    }
    public void PlayerDie() => Destroy(gameObject);
    public IEnumerator CantTakeDamage()
    {

        _playerPgc.enabled = false;
        yield return new WaitForSeconds(1);
        if(_playerPgc != null)
        _playerPgc.enabled = true;
    }
}
