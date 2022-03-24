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
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {

    }
}
