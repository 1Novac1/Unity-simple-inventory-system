using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        Transform _transform = Instantiate(item.itemPrefab, position, Quaternion.identity);
        ItemWorld _itemWorld = _transform.GetComponent<ItemWorld>();
        _itemWorld.SetItem(item);
        return _itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {   
        Vector3 _randomDir = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f)).normalized;
        ItemWorld _itemWorld = SpawnItem(dropPosition + _randomDir, item);
        return _itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("CountOfItem_Text").GetComponent<TextMeshPro>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.Amount > 1) {
            textMeshPro.gameObject.SetActive(true);
            textMeshPro.SetText(item.Amount.ToString());
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
