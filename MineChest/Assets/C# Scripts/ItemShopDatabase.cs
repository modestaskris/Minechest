using UnityEngine;

[CreateAssetMenu(fileName = "ItemShopDatabase", menuName = "Shopping/Items shop database")]
public class ItemShopDatabase : ScriptableObject
{
    public Item[] items;

    public int ItemsCount
    {
        get { return items.Length; }
    }

    public Item GetItem(int index)
    {
        return items[index];
    }

    public void PurchaseItem(int index)
    {
        items[index].isPurchased = true;
    }
}
[CreateAssetMenu(fileName = "ItemShopDatabase", menuName = "Shopping/Chests shop database")]
public class ChestShopDatabase : ScriptableObject
{
    public Chest[] chests;

    public int ChestsCount
    {
        get { return chests.Length; }
    }

    public Chest GetChest(int index)
    {
        return chests[index];
    }

    //public void PurchaseItem(int index)
    //{
    //    chests[index].isPurchased = true;
    //}
}
