using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Left_Bac,
        Right_Bac,
        Germ,
        
    };
    [Header("Enemy Type")]
    public EnemyType type;

    [Header("Speed")]
    [SerializeField] [Range(0f, 100f)] float speed;

    [Header("Bullet Prefabs")]
    GameObject[] Bullet;

    Vector3 Center;
    Transform FirePos;
    public bool isFire = false;

    void Awake()
    {
        if (type != EnemyType.Left_Bac && type != EnemyType.Right_Bac)
            FirePos = transform.GetChild(0);
    }

    void Update()
    {
        Center = transform.parent.position;
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        switch (type)
        {
            case EnemyType.Left_Bac:
                transform.RotateAround(Center, Vector3.back, speed * Time.fixedDeltaTime * -1);
                break;
            case EnemyType.Right_Bac:
                transform.RotateAround(Center, Vector3.back, speed * Time.fixedDeltaTime * 1);
                break;
            case EnemyType.Germ:
                break;
            default:
                break;
        }
        
    }

    void EnemyFire()
    {
        switch (type)
        {
            case EnemyType.Germ:
                break;
            default:
                return;
        }
    }

    void GermFire()
    {
        int term = 1;
        for (int i = 0; i<5; i++)
        {
            GameObject obj = (GameObject)Instantiate(Bullet[0]);
            obj.transform.position = FirePos.position;
            obj.GetComponent<EnemyBullet>().Direction = new Vector2(GameManager.Instance.Map_Left + term,-10);
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
