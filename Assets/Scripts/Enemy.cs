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
    public GameObject[] Bullet;

    public bool isEntered = false;
    Vector3 Center;
    Transform FirePos;
    public bool isFire = false;

    void Awake()
    {
        if (type != EnemyType.Left_Bac && type != EnemyType.Right_Bac)
            FirePos = transform.GetChild(0);
        else isEntered = true;
        EnemyEnter();
    }

    void Update()
    {
        if (type == EnemyType.Left_Bac || type == EnemyType.Right_Bac)
            Center = transform.parent.position;
    }

    private void FixedUpdate()
    {
        if (isEntered)
            EnemyMove();
    }

    void EnemyEnter()
    {
        switch (type)
        {
            case EnemyType.Germ:
                GermEnter();
                break;
        }
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
                GermFire();
                
                break;
            default:
                return;
        }
    }

    void GermEnter()
    {
        var parent = transform.parent;
        
        Vector2 target = new Vector2(transform.position.x, 1.5f);
        parent.position = Vector2.MoveTowards(transform.position,target,.1f);
        if (parent.position.y < target.y)
        {
            Invoke("GermEnter", Time.deltaTime);
            return;
        }
        Debug.Log("end");
        isEntered = true;
        EnemyFire();
    }

    void GermFire()
    {
        StopCoroutine(GermFireTiming());
        StartCoroutine(GermFireTiming());       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    IEnumerator GermFireTiming()
    { 
        for (int i = 0, term = 1; i<7;i++, term += 3)
        {
            GameObject obj = (GameObject)Instantiate(Bullet[0]);
            obj.transform.position = FirePos.position;
            if (obj.transform.position.x >= 0)
                obj.GetComponent<EnemyBullet>().Direction = new Vector2(GameManager.Instance.Map_Left + term, -10);
            else
                obj.GetComponent<EnemyBullet>().Direction = new Vector2(GameManager.Instance.Map_Right - term, -10);
            yield return new WaitForSeconds(0.17f);
        }

        Invoke("GermFire", 5);
        
    }
}
