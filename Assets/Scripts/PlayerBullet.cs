using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("BulletSpeed")]
    [SerializeField] [Range(1f,10f)] private float BulletSpeed = 6.0f;
    Rigidbody2D rb;
    float Timer = 4.0f;
    float CurrentTimer = 0.0f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        DestroyTimer(); 
    }

    void Move()
    {
        Debug.Log("Bullet Pos : " + transform.position);
        rb.AddForce(Vector2.up * BulletSpeed);
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
