using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("SpawnPoint")]
    [SerializeField]
    private Transform spawnpoint;
    public Transform Spawnpoint { get { return spawnpoint; } }

    [Header("Spawn Group")]
    [SerializeField]
    private List<GameObject> spawnGroup;
    public List<GameObject> SpawnGroup { get { return spawnGroup; } }

    [Header("Boss Group")]
    [SerializeField]
    private List<GameObject> bossGroup;
    public List<GameObject> BossGroup { get { return bossGroup; } }

    private void Update()
    {
        if (!GameManager.Instance.IsPhase)
        {
            GameManager.Instance.IsPhase = true;
            if (GameManager.Instance.PhaseCount < 5)
                SpawnEnemey();
            else
            {
                // Boss Spawn
                BossSpawn();
            }
        }
    }

    void SpawnEnemey()
    {
        GameObject obj = (GameObject)Instantiate(SpawnGroup[Random.Range(0, SpawnGroup.Count)]);
        obj.transform.position = Spawnpoint.position;
        GameManager.Instance.PhaseCount += 1;
    }

    void BossSpawn()
    {
        GameObject obj = (GameObject)Instantiate(BossGroup[(int)GameManager.Instance.stage]);
        obj.transform.position = Spawnpoint.position;
    }
}
