using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 및 모든 적에 대한 공격력 및 체력을 관리
/// </summary>
public class Actor : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private int atk;
    public int Atk { get { return atk; } }
}
