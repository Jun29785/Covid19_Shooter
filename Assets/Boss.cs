using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Actor
{
    public BossType bossType;

    [Header("Bullets")] [SerializeField]
    private List<GameObject> bullets;
    public List<GameObject> Bullets { get { return bullets; } }

    [Header("Spawn Enemys")] [SerializeField]
    private List<GameObject> enemys;
    public List<GameObject> Enemys { get { return enemys; } }

    [Header("Bullet Parent")]
    [SerializeField]
    private Transform parent;
    public Transform Parent { get { return parent; } }

    private void Awake()
    {
        // BossEnter
        BossEnter();
    }

    void BossEnter()
    {
        // BossEnter Message

        // HP UI

        // Boss Move

        // Bullet Shoot
        BossFire();
    }

    void BossFire()
    {
        switch (Random.Range(1, 2))
        {
            case 1:
                BossPattern3();
                break;
        }
    }

    void BossPattern1()
    {
        // 부채꼴 모양으로 차레대로 발사
        StartCoroutine(BowShapeBullet());
    }

    void BossPattern2()
    {
        // 360도 방향으로 발사
        CircleFire(BossBulletType.Straight);
    }

    void BossPattern3()
    {
        // 360도 방향으로 발사 밑 일정 시간 후 총알 플레이어한테 이동
        CircleFire(BossBulletType.Return);
    }

    void BossPattern4()
    {
        // 프리팹으로 지정해둔 적 패턴 생성

    }

    void BossPattern5()
    {
        // 보스 자가 회복 체력의 20%
    }

    void CircleFire(BossBulletType type)
    {
        switch (type)
        {
            case BossBulletType.Straight:
                for (int i = 1; i <= 24; i++)
                {
                    GameObject obj = (GameObject)Instantiate(bullets[0]);
                    obj.transform.position = transform.position;
                    obj.transform.rotation = Quaternion.Euler(0, 0, i * 15);
                    obj.transform.parent = Parent;
                    obj.GetComponent<EnemyBullet>().direction = Vector3.down;
                }
                break;
            case BossBulletType.Return:
                for (int i = 1; i <= 12; i++)
                {
                    GameObject obj = (GameObject)Instantiate(bullets[0]);
                    obj.transform.position = transform.position;
                    obj.transform.rotation = Quaternion.Euler(0, 0, i * 30);
                    obj.transform.parent = Parent;
                    var bullet = obj.GetComponent<EnemyBullet>();
                    bullet.direction = Vector3.up;
                    bullet.LifeTime = 6.0f;
                    bullet.ReturnPlayer = true;
                    bullet.MoveSpeed = 8f;
                }   
                break;
        }
        
    }

    IEnumerator BowShapeBullet()
    {
        int a = 15;
        for (int i = 0, term = -90; i < 24; i++, term += 15)
        {
            if (i > 12 && term > 60) term = -90;
            if (term < 90) a *= -1;
            GameObject obj = (GameObject)Instantiate(Bullets[0]);
            obj.transform.position = transform.position;
            if (a > 0)
                obj.transform.rotation = Quaternion.Euler(0, 0, -term);
            else
                obj.transform.rotation = Quaternion.Euler(0, 0, term);
            obj.GetComponent<EnemyBullet>().direction = Vector3.down;
            yield return new WaitForSeconds(0.07f);
        }

        //Invoke("BossFire", 0.7f);
        StopCoroutine(BowShapeBullet());
    }
}
