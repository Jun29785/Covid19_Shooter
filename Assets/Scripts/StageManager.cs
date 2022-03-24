using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [Header("Stage")]
    [SerializeField]
    private Stage stage;
    public Stage Stage { get { return stage; } }

    [Header("Spawner")]
    [SerializeField]
    private Spawner spawner;
    public Spawner Spawner { get { return spawner; } }

    private void Awake()
    {
        Instance = this;
        Init();
        
    }

    void Init()
    {
        var gm = GameManager.Instance;
        switch (Stage)
        {
            case Stage.Stage1:
                gm.IsFire = false;
                gm.IsPhase = false;
                gm.BulletLevel = 1;
                gm.ItemCount = 0;
                gm.PainGauge = 10;
                gm.PhaseCount = 0;
                gm.stage = Stage.Stage1;
                break;
            case Stage.Stage2:
                gm.PainGauge = 30;
                gm.IsPhase = false;
                gm.stage = Stage.Stage2;
                break;
        }

    }
}
