using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyBullet : Bullet
{
    public Vector2 Target;

    float LifeTime = 5.0f;
    float Timer = 0;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        DestroyTimer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        switch(Function)
        {
            case BulletFunction.Straight:
                transform.position = Vector2.MoveTowards(transform.position, Target,0.1f);
                break;

        }
    }

    void DestroyTimer()
    {
        Timer += Time.deltaTime;
        if (Timer > LifeTime)
        {
            Destroy(this.gameObject);   
        }
    }
}
