using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory; // Create inventory

    private PlayerController playerController;

    [SerializeField] private UI_Inventory ui_Inventory;

    private void Awake()
    {
        playerController = this.transform.GetChild(0).GetComponent<PlayerController>();
        inventory = new Inventory();
        ui_Inventory.Setinventory(inventory);
        ui_Inventory.playerController = this.playerController;
    }

    void Start()
    {
        // Spawn items for test
        ItemWorld.SpawnItem(new Vector3(-1,1), new ItemsCollection.Apple());
        ItemWorld.SpawnItem(new Vector3(1,1), new ItemsCollection.GoldenKey());
        ItemWorld.SpawnItem(new Vector3(0, 1), new ItemsCollection.GoldenKey());
        ItemWorld.SpawnItem(new Vector3(2, 1), new ItemsCollection.GoldenKey());
        ItemWorld.SpawnItem(new Vector3(2.5f, 1), new ItemsCollection.GoldenKey());
        ItemWorld.SpawnItem(new Vector2(3, 2), new ItemsCollection.Apple());
        //---------------------
    }
}