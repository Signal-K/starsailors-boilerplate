using UnityEngine;
using LootLocker.Requests;

public class Lootlocker : MonoBehaviour
{
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });

        LootLockerSDKManager.SetPlayerName("Chris", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Error setting player name");
            }
        });

        LootLockerSDKManager.GetInventory((response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully retrieved player inventory: " + response.inventory.Length);

                foreach(var item in response.inventory)
                {
                    Debug.Log("fill item with " + item.asset.name);

                    switch (item.asset.name)
                    {
                        case "Item_1":
                            Inventory.Instance.inventory.Add(new Item(Item.Type.rabbit));
                            break;
                        case "Item_2":
                            Inventory.Instance.inventory.Add(new Item(Item.Type.sun));
                            break;
                        case "Item_3":
                            Inventory.Instance.inventory.Add(new Item(Item.Type.spade));
                            break;
                    }
                }

                Inventory.Instance.Backpack.RefreshItems(0);
                Inventory.Instance.Store.RefreshItems(0);
            }
            else
            {
                Debug.Log("Error getting player inventory");
            }
        });
    }
}
