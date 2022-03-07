using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;

    [Header("Move Speed")]
    [SerializeField] [Range(1f,30f)]private float MoveSpeed = 10.0f;

    [Header("Player Bullet Prefabs")]
    public GameObject PlayerBulletPrefabs;

    [Header("Bullet Parent")]
    public Transform BulletParent;

    void Start()
    {
        
    }

    void Update()
    {
        InputKey();
        Fire();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKey()
    {
        moveX = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
        moveY = Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.IsFire = true;
        }
    }

    void Move()
    {
       

        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

    void Fire()
    {
        if (GameManager.Instance.IsFire)
        {
            // Create Bullet
            GameObject obj = (GameObject)Instantiate(PlayerBulletPrefabs);
            obj.transform.position = BulletParent.position;
            // IsFire false
            GameManager.Instance.IsFire = false;
        }
    }
}
