using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance;

    [Header("Player")] [SerializeField]
    private GameObject player;
    public GameObject Player { get { return player; } }

    private void Awake()
    {
        Instance = this;
    }
}
