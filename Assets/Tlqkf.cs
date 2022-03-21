using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlqkf : MonoBehaviour
{
    [SerializeField]
    [Range(-360, 360)]
    private float rotation;
    public float Rotation { get { return rotation; } }
    // Start is called before the first frame update
    void Start()
    {

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
