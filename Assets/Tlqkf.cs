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
        transform.Translate(Dir * 1f * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            key();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            front();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            t();
        }
    }

    void t()
    {
        Dir = (PlayManager.Instance.Player.transform.position -
            transform.position).normalized;
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
