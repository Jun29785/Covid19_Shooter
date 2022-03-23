using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Type")]
    public BulletType BulletType;
    [Header("Bullet Speed")] [SerializeField] [Range(0f,5f)]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
}
