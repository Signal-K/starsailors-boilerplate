using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : InstanceMonoBehaviour<Inventory>
{
    public ItemWindow Backpack;
    public ItemWindow Store;

    public List<Item> inventory = new List<Item>();

    protected override void Awake()
    {
        base.Awake();

        Backpack.Init(inventory, 7, 4, false);
        Store.Init(inventory, 7, 1, true);
    }
}
