using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private void Update()
    {
        if (transform.GetChildCount() == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 0.2f);
        
    }
}
