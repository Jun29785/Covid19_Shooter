using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 Direction;

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
        Debug.Log("Current Pos : " + transform.position + "\nTarget : " + Direction);
        transform.position = Vector2.MoveTowards(transform.position, Direction,0.1f);
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
