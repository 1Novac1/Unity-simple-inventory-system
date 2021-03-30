using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerManager playerManager;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerManager = transform.parent.GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * 8, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * 8, 0.8f));
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemWorld>() is ItemWorld _itemWorld)
        {
            if (_itemWorld != null && !playerManager.inventory.HasInventoryFulled(_itemWorld.GetItem()))
            {
                playerManager.inventory.AddItem(_itemWorld.GetItem());
                _itemWorld.DestroySelf();
            }
        }
    }
}
