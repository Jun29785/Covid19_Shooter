using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Enemy em;
    private void Awake()
    {
        em = transform.GetChild(0).GetComponent<Enemy>();
    }
    private void Update()
    {
        if (transform.GetChildCount() == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (em.type == Enemy.EnemyType.Germ)
        {
            return;
        }
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 0.2f);
    }
}
