using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Bullet Speed")]
    [SerializeField] [Range(1f,15f)] private float BulletSpeed = 6.0f;

    [Header("Bullet Type")]
        

    float move;
    float Timer = 1.0f;
    float CurrentTimer = 0.0f;
    
    private void Awake()
    {
        move = Time.deltaTime * BulletSpeed;
    }

    void Update()
    {
        Move();
        DestroyTimer(); 
    }

    void Move()
    {
        Debug.Log("Bullet Pos : " + transform.position);
        transform.position = new Vector2(transform.position.x, transform.position.y + move);
    }
    
    void DestroyTimer()
    {
        CurrentTimer += Time.deltaTime;
        if (Timer < CurrentTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
