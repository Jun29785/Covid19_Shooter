using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX, moveY;
    [Header("MoveSpeed")]
    [SerializeField] [Range(1f,30f)]private float MoveSpeed = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
        moveY = Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }
}
