using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerRunSpeed;
    private Rigidbody2D playerRigibody2D;
    private Animator playerAnimator;
    public float playerJumpSpeed;
    private bool _isJump;
    public static bool isFlip;
    public bool _isGround;
    public BoxCollider2D _myFeet;
    public float doubleJumpSpeed;
    public bool _canDoubleJump;
    private PlayerAttack _playerAttack;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {

        playerRigibody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        _myFeet = GetComponent<BoxCollider2D>();
        _playerAttack = GetComponentInChildren<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        groundJudge();
        jumpInput();
        cheakGround();
        switchJumpAnimation();
        playerFilp();
        
    }
    private void FixedUpdate()
    {
        playerRun();
        playerJump();

    }
    void playerFilp()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigibody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (playerRigibody2D.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
                isFlip = false;
            }
            if (playerRigibody2D.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                isFlip = true;
            }
        }

    }
    void playerRun()
    {
        float playerDic = Input.GetAxis("Horizontal");
        Vector2 playerVector2 = new Vector2(playerDic * playerRunSpeed,playerRigibody2D.velocity.y);
        playerRigibody2D.velocity = playerVector2;
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigibody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Run",playerHasXAxisSpeed);
    }
    void playerJump()
    {

        if (_isJump&&_isGround)
        {
            playerRigibody2D.velocity =  new Vector2(0.0f, playerJumpSpeed);
            _isJump = false;
        }

        else if (_isJump && _canDoubleJump)
        {
            Vector2 doubleJump = new Vector2(playerRigibody2D.velocity.x, doubleJumpSpeed);
            playerRigibody2D.velocity = doubleJump;
            _canDoubleJump = false;
            _isJump = false;
        }

    }
    void cheakGround()
    {
        _isGround = _myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))||
            _myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))||
            _myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));

    }
    void switchJumpAnimation()
    {
        playerAnimator.SetBool("isRise", playerRigibody2D.velocity.y > 0.01f);
        playerAnimator.SetBool("isFall", playerRigibody2D.velocity.y < -0.01f);
        playerAnimator.SetBool("isGround", Mathf.Abs(playerRigibody2D.velocity.y) < 0.01f);
        playerAnimator.SetBool("isDoubleJump", !_canDoubleJump);
    }
    void jumpInput()
    {

        if ( _canDoubleJump)
        {
            _isJump |= Input.GetButtonDown("Jump");
        }
    }
    void groundJudge()
    {
        if (_isGround)
        {
            _canDoubleJump = true;
        }
    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            playerAnimator.SetTrigger("Attack");
        }
    }
    /// <summary>
    /// 此方法内部是子对象中控制攻击触发器显现隐藏的方法。
    /// </summary>
    /// <param name="magicNumber">当参数为1时，polygonCollider显现，当参数为0时，polygonCollider隐藏</param>
    void AttackEvent(int magicNumber)
    { 
        _playerAttack.AttackEvent(magicNumber);
    }
}
