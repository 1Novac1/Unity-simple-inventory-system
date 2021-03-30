using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> itemFields;

    public event EventHandler OnItemListChanged;
 
    public Inventory()
    {
        itemFields = new List<Item>();
        Debug.Log("Inventory created");
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable == true)
        {
            bool _hasAlreadyInInventory = false;
            foreach(Item inventoryItem in itemFields)
            {
                if(inventoryItem.GetType() == item.GetType())
                {
                    inventoryItem.Amount += item.Amount;
                    _hasAlreadyInInventory = true;
                }
            }
            if(!_hasAlreadyInInventory) { itemFields.Add(item); }
        }
        else itemFields.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty); // call event for subscribers
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable == true)
        {
            Item _itemInInventory = null;
            foreach (Item inventoryItem in itemFields)
            {
                if (inventoryItem.GetType() == item.GetType())
                {
                    inventoryItem.Amount -= item.Amount;
                    _itemInInventory = inventoryItem;
                }
            }
            if (_itemInInventory != null && _itemInInventory.Amount <= 0) { itemFields.Remove(_itemInInventory); }
        }
        else itemFields.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty); // call event for subscribers
    }

    public List<Item> GetItemList()
    {
        return itemFields;
    }

    private bool HasInInventory(Item item)
    {
        foreach (Item inventoryItem in itemFields)
        {
            if (inventoryItem.GetType() == item.GetType())
            {
                return true;
            }
        }
        return false;
    }

    public bool HasInventoryFulled(Item item)
    {
        if (itemFields.Count < 8) return false;
        else {        
            if (HasInInventory(item) && item.IsStackable == true) return false; 
            else  return true; 
        }
    }
}

