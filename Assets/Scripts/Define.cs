namespace Define 
{
    public enum BulletType
    {
        Player,
        Enemy,
    }
    public enum EnemyType
    {
        Bacteria,
        Germ,
        Cancer,
        Virus

    };
    public enum EnemyDirection
    {
        Left = -1,
        Center = 0,
        Right = 1
    }
    public enum BulletFunction
    {
        FollowPlayer,
        Straight
    }
    public enum BossType
    {
        Covid,
        Evolved_Covid
    }
    public enum BossBulletType
    {
        Straight,
        Return
    }
    public enum ItemType
    {
        Upgrade,
        God,
        Heal,
        Pain
    }
    public enum Stage
    {
        Stage1 = 0,
        Stage2 = 1
    }
    public enum CellType
    {
        White = 0,
        Red = 1
    }
}
