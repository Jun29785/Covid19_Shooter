using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlqkf : MonoBehaviour
{
    [SerializeField]
    [Range(-360, 360)]
    private float rotation;
    public float Rotation { get { return rotation; } }

    private float TimingTimer;

    public EnemyDirection Direction;

    Vector3 Dir;
    // Start is called before the first frame update
    void Start()
    {
        Dir = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            key();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            front();
        }
        ZigZagTest();
    }

    void ZigZagTest()
    {
        TimingTimer += Time.deltaTime;
        if(TimingTimer > 1)
        {
            TimingTimer = 0;
            Dir = Vector3.down;
        }
        else if(TimingTimer > .5)
        {
            Dir =  new Vector3((float)Direction,0,0);
        }
        transform.Translate(Dir * 2 * Time.deltaTime);
    }
    
    void key()
    {
        transform.LookAt(PlayManager.Instance.Player.transform);
    }

    void front()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 10);
    }
}
