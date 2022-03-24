using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Speed")]
    [SerializeField] [Range(1f,30f)]private float MoveSpeed = 10.0f;

    [Header("Player Bullet Prefabs")]
    public GameObject PlayerBulletPrefabs;

    [Header("Bullet Parent")]
    public Transform BulletParent;

    private float FireCoolTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    private void FixedUpdate()
    {
        InputKey();
    }

    void InputKey()
    {
        // 이동 구역 제한 지정해야됨
        Vector2 direction =  new Vector2();
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.5)
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.5)
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.4)
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.4)
        {
            direction += Vector2.right;
        }

        transform.Translate(direction * MoveSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space) && !GameManager.Instance.IsFire)
        {
            FireCoolTime = 0;
            GameManager.Instance.IsFire = true;
        }
    }

    void Fire()
    {
        FireCoolTime += Time.deltaTime;
        if (GameManager.Instance.IsFire && FireCoolTime > 0.2)
        {
            // Create Bullet
            GameObject obj = (GameObject)Instantiate(PlayerBulletPrefabs);
            obj.transform.position = BulletParent.position;
            // IsFire false
            GameManager.Instance.IsFire = false;
        }
    }
}
