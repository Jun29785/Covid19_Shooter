 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    [SerializeField]
    private ItemType itemType;
    public ItemType ItemType { get { return itemType; } }

    // 움직임은 단순 떨어지기 (rigidbody 이용해서 구현)

    void ItemEffect()
    {
        switch (ItemType)
        {
            case ItemType.Upgrade:
                
                break;
            case ItemType.God:
                break;
            case ItemType.Heal:
                break;
            case ItemType.Pain:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Effect
        }
    }
}
