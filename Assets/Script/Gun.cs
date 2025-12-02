using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector3 _mousePos;
    public Vector2 gunDirection;
    private float _angle;
    public new Camera camera;
    public GameObject muzzle;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        gunDirection = (_mousePos - transform.position).normalized;
        _angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, _angle);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(transform.eulerAngles));
            bulletClone.GetComponent<Rigidbody2D>().velocity = gunDirection * bulletClone.GetComponent<Bullet>().speed;
            StartCoroutine(bulletClone.GetComponent<Bullet>().FlyTime());

        }

    }

}
