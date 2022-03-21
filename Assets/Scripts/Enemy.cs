using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Enemy : MonoBehaviour
{
    
    [Header("Enemy Type")]
    public EnemyType type;

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
        if (type != EnemyType.Left_Bac && type != EnemyType.Right_Bac)
            FirePos = transform.GetChild(0);
        else isEntered = true;
        EnemyEnter();
    }

    void Update()
    {
            Center = transform.parent;
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
            case EnemyType.Left_Bac:
                transform.RotateAround(Center.position, Vector3.back, speed * Time.fixedDeltaTime * -1);
                break;
            case EnemyType.Right_Bac:
                transform.RotateAround(Center.position, Vector3.back, speed * Time.fixedDeltaTime * 1);
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
        if (Center.position.y > -1)
        {
            Invoke("CancerEnter", Time.deltaTime);
            return;
        }
        Debug.Log("end");
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
        // 모든 방향으로 총알 발사
            
    }

    void VirusFire()
    {

    }
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
