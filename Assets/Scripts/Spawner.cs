using Define;
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

    [Header("Item Prefabs")]
    [SerializeField]
    private List<GameObject> items;
    public List<GameObject> Items { get { return items; } }

    [Header("Cell Prefabs")]
    [SerializeField]
    private List<GameObject> cells;
    public List<GameObject> Cells { get { return cells; } }

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

        if ()
    }

    void SpawnEnemey()
    {
        GameObject obj = (GameObject)Instantiate(SpawnGroup[Random.Range(0, SpawnGroup.Count)]);
        obj.transform.position = Spawnpoint.position;
        GameManager.Instance.PhaseCount += 1;
    }

    void SpawnCells(CellType type)
    {
        // 적혈구 및 백혈구 소환
        GameObject obj = (GameObject)Instantiate(Cells[(int)type]);
        Vector2 pos = new Vector2(Random.RandomRange(-8.48f,8.48f), 6);
        obj.transform.position = pos;
        
    }

    void BossSpawn()
    {
        GameObject obj = (GameObject)Instantiate(BossGroup[(int)GameManager.Instance.stage]);
        obj.transform.position = Spawnpoint.position;
    }

    public void CreateItem(Transform enemy)
    {
        if (GameManager.Instance.BulletLevel < 5)
        {
            GameObject obj = (GameObject)Instantiate(Items[Random.Range(1, 7)]);
            obj.transform.position = enemy.position;
        }
        else
        {
            GameObject obj = (GameObject)Instantiate(Items[Random.Range(2, 7)]);
            obj.transform.position = enemy.position;
        }
    }
}
