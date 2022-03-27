using UnityEngine;
using Define;

public class GameManager : Singleton<GameManager>
{
    public bool IsFire;

    public bool IsPhase;

    public int BulletLevel;

    public int ItemCount;

    public int PainGauge;

    public int PhaseCount;

    public Stage stage;

    public bool IsCellSpwan;

    [Header("Player Stat")]
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } set { hp = value; } }
    [SerializeField]
    private int atk;
    public int Atk { get { return atk; } set { atk = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }   
}
