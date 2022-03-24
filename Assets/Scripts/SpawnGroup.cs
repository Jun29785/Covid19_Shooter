using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroup : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount < 1)
        {
            GameManager.Instance.IsPhase = false;
            Destroy(this.gameObject);
        }
    }
}
