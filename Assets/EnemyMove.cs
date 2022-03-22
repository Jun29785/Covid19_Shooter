using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyMove : MonoBehaviour
{
    Enemy em;

    [SerializeField] [Range(0,3)]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    public EnemyDirection Direction;

    Vector3 Dir;
    float TimingTimer;

    private void Awake()
    {
        em = transform.GetChild(0).GetComponent<Enemy>();
        Dir = Vector3.down;
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
                case EnemyType.Virus:
                    TimingTimer += Time.deltaTime;
                    if (TimingTimer > 1)
                    {
                        TimingTimer = 0;
                        Dir = Vector3.down;
                    }
                    else if(TimingTimer > .5)
                    {
                        Dir = new Vector3((float)Direction, 0, 0);
                    }
                    transform.Translate(Dir * 2 * Time.deltaTime);
                    break;
                default: // left_bac, right_bac
                    transform.Translate(Vector3.down * Time.fixedDeltaTime * MoveSpeed);
                    break;
            }
        }
    }
}
