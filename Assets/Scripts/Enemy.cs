using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Enemy : Actor
{
    [Header("Enemy Type")]
    public EnemyType type;

    [Header("Enemy Direction")]
    public EnemyDirection Direction;

    [Header("Speed")]
    [SerializeField] [Range(0f, 100f)] float speed;

    [Header("Bullet Prefabs")]
    public GameObject[] Bullet;

    public bool isEntered = false;
    Transform Center;
    Transform FirePos;
    public bool isFire = false;

    void Awake()
    {
        Center = transform.parent;
        if (type != EnemyType.Bacteria)
            FirePos = transform.GetChild(0);
        else isEntered = true;
        EnemyEnter();
    }

    void Update()
    {
        Center = transform.parent;
        //Debug.Log(Hp);
        if (Hp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
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
            case EnemyType.Cancer:
                CancerEnter();
                break;
            case EnemyType.Virus:
                VirusEnter();
                break;
            default:
                break;
        }
    }

    void EnemyMove()
    {
        switch (type)
        {
            case EnemyType.Bacteria:
                transform.RotateAround(Center.position, Vector3.back, speed * Time.fixedDeltaTime * (int)Direction);
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
            case EnemyType.Cancer:
                CancerFire();
                break;
            case EnemyType.Virus:
                VirusFire();
                break;
            default:
                return;
        }
    }

    #region Germ

    void GermEnter()
    {
        Vector2 target = new Vector2(Center.position.x, 0.7f);
        transform.parent.position = Vector2.MoveTowards(Center.position,target,.1f);
        if (Center.position.y < target.y)
        {
            Invoke("GermEnter", Time.deltaTime);
            return;
        }
        isEntered = true;
        EnemyFire();
    }

    void GermFire()
    {
        StopCoroutine(GermFireTiming());
        StartCoroutine(GermFireTiming());       
    }

    IEnumerator GermFireTiming()
    { 
        for (int i = 0, term = -90; i<7;i++, term += 30)
        {
            GameObject obj = (GameObject)Instantiate(Bullet[0]);
            obj.transform.position = FirePos.position;
            if (obj.transform.position.x >= 0)
                obj.transform.rotation = Quaternion.Euler(0, 0, term);
            else
                obj.transform.rotation = Quaternion.Euler(0, 0, -term);
            obj.GetComponent<EnemyBullet>().direction = Vector3.down;
            yield return new WaitForSeconds(0.07f);
        }

        Invoke("GermFire", 2f);
        
    }

    #endregion

    #region Cancer

    void CancerEnter()
    {
        Center.Translate(Vector2.down * Time.deltaTime * speed);
        if (Center.position.y > 1.7)
        {
            Invoke("CancerEnter", Time.deltaTime);
            return;
        }
        isEntered = true;
        EnemyFire();
    }

    void CancerFire()
    {
        // Create Obj
        GameObject obj = (GameObject)Instantiate(Bullet[0]);
        obj.transform.position = FirePos.position;
        var player = PlayManager.Instance.Player;
        obj.GetComponent<EnemyBullet>().SetDirection(
            BulletFunction.FollowPlayer, 
            obj.transform.position, 
            player.transform.position);
        Invoke("CancerFire", Random.Range(1.0f,2.5f));
    }

    #endregion

    #region Virus
    void VirusEnter()
    {
        Center.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (Center.transform.position.y > 5.7)
        {
            Invoke("VirusEnter", Time.deltaTime);
            return;
        }
        isEntered = true;
        VirusFire();
    }

    void VirusFire()
    {
        // 모든 방향으로 총알 발사

        for (int i = 0,angle = 360; i<12; i++,angle -= 30)
        {
            GameObject obj = (GameObject)Instantiate(Bullet[0]);
            obj.transform.position = FirePos.position;
            obj.transform.rotation = Quaternion.Euler(0, 0, angle);
            obj.GetComponent<EnemyBullet>().direction = Vector3.down;
        }

        // 다시 실행
        Invoke("VirusFire", Random.Range(1.0f, 2.0f));
    }

    #endregion

    public void GetDamage(int dmg)
    {
        Hp -= dmg;
        //Debug.Log("HP : " + Hp);
    }
}
