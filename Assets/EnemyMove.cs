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
        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        switch(em.type)
        {
            case Enemy.EnemyType.Germ:
                if (em.isEntered)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 0.2f);
                }
                break;
            default: // left_bac, right_bac
                transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 0.2f);
                break;
        }
    }
}
