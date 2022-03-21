using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyBullet : Bullet
{
    public Vector2 direction;

    [Header("BulletLifeTime")][SerializeField][Range(0,5)]
    private float lifeTime = 3.0f;
    public float LifeTime { get { return lifeTime; } }
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
        transform.Translate(direction * Time.fixedDeltaTime * MoveSpeed);
    }

    public void SetDirection(BulletFunction f, Vector2 obj, Vector2 target)
    {
        switch (f)
        {
            case BulletFunction.FollowPlayer:
                direction = (target - obj).normalized;
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
