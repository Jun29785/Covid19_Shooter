using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Bullet Speed")]
    [SerializeField] [Range(1f,5f)] 
    private float bulletSpeed;
    public float BulletSpeed { get { return bulletSpeed; } }

    float Timer = 3f;
    float CurrentTimer = 0.0f;
    
    void Update()
    {
        Move();
        DestroyTimer(); 
    }

    void Move()
    {
        //Debug.Log("Bullet Pos : " + transform.position);
        transform.Translate(Vector3.up * Time.fixedDeltaTime * BulletSpeed);
    }
    
    void DestroyTimer()
    {
        CurrentTimer += Time.deltaTime;
        if (Timer < CurrentTimer)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(GameManager.Instance.Atk);
            Destroy(this.gameObject);
        }
    }
}
