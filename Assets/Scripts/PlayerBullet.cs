using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float BulletSpeed = 3.0f;
    Rigidbody2D rb;
    float Timer = 5.0f;
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
        rb.AddForce(Vector2.up * BulletSpeed, ForceMode2D.Force);
    }
    
    void DestroyTimer()
    {
        CurrentTimer += Time.deltaTime;
        if (Timer < CurrentTimer)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
        Debug.Log("currentTimer : " + CurrentTimer);
    }
}
