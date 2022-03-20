using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyMove : MonoBehaviour
{
    Enemy em;

    [SerializeField]
    [Range(0,3)]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

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
        if (em.isEntered)
        {
            switch (em.type)
            {
                case EnemyType.Germ:
                    transform.Translate(Vector3.up * Time.fixedDeltaTime * MoveSpeed);
                    break;
                case EnemyType.Cancer:
                    transform.Translate(Vector3.down * Time.fixedDeltaTime * MoveSpeed);
                    break;
                default: // left_bac, right_bac
                    transform.Translate(Vector3.down * Time.fixedDeltaTime * MoveSpeed);
                    break;
            }
        }
    }
}
