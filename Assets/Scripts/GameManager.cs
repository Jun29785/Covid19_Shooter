using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Define define;

    public bool IsFire = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        
    }
}
