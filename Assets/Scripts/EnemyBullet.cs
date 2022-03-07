using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 Direction;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2.MoveTowards(transform.position, Direction,10);
    }

    
}
