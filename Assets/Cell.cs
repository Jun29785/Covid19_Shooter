using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Cell : MonoBehaviour
{
    [Header("Cell Type")]
    [SerializeField]
    private CellType type;
    public CellType Type { get { return type; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {

        }
        if (collision.CompareTag("Player"))
        {

        }
    }
}
