using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyBullet : Bullet
{
    public Vector2 direction;

    [Header("BulletLifeTime")][SerializeField][Range(0,5)]
    private float lifeTime = 3.0f;
    public float LifeTime { get { return lifeTime; } set { lifeTime = value; } }
    float Timer = 0;
    public bool ReturnPlayer = false;

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
        transform.Translate(direction * Time.deltaTime * MoveSpeed);
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
        if (Timer > 1.5 && ReturnPlayer)
        {
            MoveSpeed += 1f;
            direction = (PlayManager.Instance.Player.transform.position -
                transform.position).normalized;
            transform.rotation = Quaternion.identity;
            Debug.Log(direction);
            ReturnPlayer = false;
        }
        if (Timer > LifeTime)
        {
            Destroy(this.gameObject);   
        }
    }
}
