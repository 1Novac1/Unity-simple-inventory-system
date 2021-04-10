using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            if (IsStackable == true)
            {
                amount = value;
            }
            else { amount = 1; }
        }
    }

    public Transform itemPrefab = Resources.Load<Transform>("Prefabs/ItemPrefab");

    public virtual Item Clone() => this;

    public abstract bool IsStackable { get; }

    public abstract Sprite GetSprite();
}
