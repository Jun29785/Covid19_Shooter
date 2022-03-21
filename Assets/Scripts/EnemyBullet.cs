using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyBullet : Bullet
{
    float LifeTime = 3.0f;
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
        transform.Translate(Vector3.down * Time.fixedDeltaTime * MoveSpeed);
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
