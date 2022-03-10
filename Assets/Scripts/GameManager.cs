using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsFire = false;

    public float Map_Left = -9;
    public float Map_Right = 9;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
    }
}
