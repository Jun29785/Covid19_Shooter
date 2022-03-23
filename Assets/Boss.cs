using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossType bossType;

    [Header("Bullets")] [SerializeField]
    private List<GameObject> bullets;
    public List<GameObject> Bullets { get { return bullets; } }

    [Header("Spawn Enemys")] [SerializeField]
    private List<GameObject> enemys;
    public List<GameObject> Enemys { get { return enemys; } }

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
                BossPattern1();
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
    }

    void BossPattern3()
    {
        // 360도 방향으로 발사 밑 일정 시간 후 총알 플레이어한테 이동
    }

    void BossPattern4()
    {
        // 랜덤한 적 생성
    }

    void BossPattern5()
    {

    }

    IEnumerator BowShapeBullet()
    {
        int a = 15;
        for (int i = 0, term = -90; i < 12; i++, term += 15)
        {
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
