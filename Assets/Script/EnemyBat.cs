using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBat : Enemy
{
    public float _health;
    public float _damage;
    public float startWaitTime;
    private float _waitTime;
    public float moveSpeed;
    public Transform movePos;
    public Transform leftPos;
    public Transform rightPos;
    private new void Awake()
    {
        base.Awake();
        _waitTime = startWaitTime;
        movePos.position = RandomPos();
    }
    private new void Update()
    {
        base.Update();
        EnemyMove();
    }
    public override float health { get => _health; set => _health = value; }
    public override float damage { get => _damage; set => _damage = value; }
    Vector2 RandomPos()
    {
        Vector2 movPos = new Vector2(UnityEngine.Random.Range(leftPos.position.x,rightPos.position.x),UnityEngine.Random.Range(leftPos.position.y,rightPos.position.y));
        return movPos;
    }
    void EnemyMove()
    {
        transform.position =  Vector2.MoveTowards(transform.position,movePos.position,moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) <= .2f)
        {
            if (_waitTime <= 0)
            {
                movePos.position = RandomPos();
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }

    }    
}

