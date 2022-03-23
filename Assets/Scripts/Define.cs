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
}
