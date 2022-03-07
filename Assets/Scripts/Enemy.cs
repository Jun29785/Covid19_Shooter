using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Left,
        Center,
        Right
    };
    [Header("Enemy Type")]
    public EnemyType type;

    [SerializeField] [Range(0f, 100f)] float speed;

    Vector3 Center;

    void Awake()
    {
        
    }

    void Update()
    {
        Center = transform.parent.position;
    }

    private void FixedUpdate()
    {
        CircleMove();
    }

    void CircleMove()
    {
        switch (type)
        {
            case EnemyType.Left:
                transform.RotateAround(Center, Vector3.back, speed * Time.fixedDeltaTime * -1);
                break;
            case EnemyType.Center:
                break;
            case EnemyType.Right:
                transform.RotateAround(Center, Vector3.back, speed * Time.fixedDeltaTime * 1);
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
