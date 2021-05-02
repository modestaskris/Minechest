using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShopUI : MonoBehaviour
{
    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = .5f;
    float itemWidth = 200;

    [Header("UI elements")]
    [SerializeField] Transform ShopMenu;
    [SerializeField] Transform ShopToolsContainer;
    [SerializeField] GameObject toolPrefab;
    [Space(20)]
    [SerializeField] ItemShopDatabase toolDB;

    [Header("clothing UI elements")]
    [SerializeField] Transform ShopClothingContainer;
    [SerializeField] GameObject clothingPrefab;
    [Space(20)]
    [SerializeField] ItemShopDatabase clothingDB;

    [Header("chests UI elements")]
    [SerializeField] Transform ShopChestsContainer;
    [SerializeField] GameObject chestPrefab;
    [Space(20)]
    [SerializeField] ChestShopDatabase chestsDB;

    [Space(20)]
    [Header("Shop Events")]
    [SerializeField] GameObject shopUI;
    [SerializeField] Animator NoCoinsAnim;


    void Start()
    {

        //Fill the shop's UI list with items
        GenerateShopItemsUI();

    }


    void GenerateShopItemsUI()
    {
        //Loop throw save purchased items and make them as purchased in the Database array
        for (int i = 0; i < GameDataManager.GetAllPurchasedTools().Count; i++)
        {
            int purchasedToolIndex = GameDataManager.GetPurchasedTool(i);
            toolDB.PurchaseItem(purchasedToolIndex);
        }
        for (int i = 0; i < GameDataManager.GetAllPurchasedClothings().Count; i++)
        {
            int purchasedClothingIndex = GameDataManager.GetPurchasedClothing(i);
            clothingDB.PurchaseItem(purchasedClothingIndex);
        }


        //Generate Items
        for (int i = 0; i < toolDB.ItemsCount; i++)
        {
            //Create a Character and its corresponding UI element (uiItem)
            Item item = toolDB.GetItem(i);
            ItemUI uiItem = Instantiate(toolPrefab, ShopToolsContainer).GetComponent<ItemUI>();

            //Move item to its position
            uiItem.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

            //Set Item name in Hierarchy (Not required)
            uiItem.gameObject.name = "Item" + i + "-" + item.name;

            //Add information to the UI (one item)
            uiItem.SetItemName(item.name);
            uiItem.SetItemImage(item.image);
            uiItem.SetItemPrice(item.price);
           

            if (item.isPurchased)
            {
                //Character is Purchased
                uiItem.SetItemAsPurchased();
            }
            else
            {
                //Character is not Purchased yet
                uiItem.OnItemPurchase(i, OnToolPurchased);
            }

        }
        for (int i = 0; i < clothingDB.ItemsCount; i++)
        {
            //Create a Character and its corresponding UI element (uiItem)
            Item item = clothingDB.GetItem(i);
            ItemUI uiItem = Instantiate(clothingPrefab, ShopClothingContainer).GetComponent<ItemUI>();

            //Move item to its position
            uiItem.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

            //Set Item name in Hierarchy (Not required)
            uiItem.gameObject.name = "Item" + i + "-" + item.name;

            //Add information to the UI (one item)
            uiItem.SetItemName(item.name);
            uiItem.SetItemImage(item.image);
            uiItem.SetItemPrice(item.price);

            if (item.isPurchased)
            {
                //Character is Purchased
                uiItem.SetItemAsPurchased();
            }
            else
            {
                //Character is not Purchased yet
                uiItem.OnItemPurchase(i, OnClothingPurchased);
            }

        }
        //Generate Chests
        for (int i = 0; i < chestsDB.ChestsCount; i++)
        {
            //Create a Character and its corresponding UI element (uiItem)
            Chest chest = chestsDB.GetChest(i);
            ItemUI uiItem = Instantiate(toolPrefab, ShopChestsContainer).GetComponent<ItemUI>();

            //Move item to its position
            uiItem.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));

            //Set Item name in Hierarchy (Not required)
            uiItem.gameObject.name = "Item" + i + "-" + chest.name;

            //Add information to the UI (one item)
            uiItem.SetItemName(chest.name);
            uiItem.SetItemImage(chest.image);
            uiItem.SetItemPrice(chest.price);

                uiItem.OnItemPurchase(i, OnChestPurchased);


        }
    }
    void OnToolPurchased(int index)
    {
        Item item = toolDB.GetItem(index);
        ItemUI uiItem = GetToolUI(index);

        if (GameDataManager.CanSpendCoins(item.price))
        {
            //Proceed with the purchase operation
            GameDataManager.SpendCoins(item.price);

            //Update Coins UI text
            GameSharedUI.Instance.UpdateCoinsUIText();

            //Update DB's Data
            toolDB.PurchaseItem(index);

            uiItem.SetItemAsPurchased();

            //Add purchased item to Shop Data
            GameDataManager.AddPurchasedTool(index);

        }
        else
        {
            //No enough coins..
            NoCoinsAnim.SetTrigger("NoCoins");
        }
    }
    void OnClothingPurchased(int index)
    {
        Item item = clothingDB.GetItem(index);
        ItemUI uiItem = GetClothingUI(index);

        if (GameDataManager.CanSpendCoins(item.price))
        {
            //Proceed with the purchase operation
            GameDataManager.SpendCoins(item.price);

            //Play purchase FX
            //purchaseFx.Play();

            //Update Coins UI text
            GameSharedUI.Instance.UpdateCoinsUIText();

            //Update DB's Data
            clothingDB.PurchaseItem(index);

            uiItem.SetItemAsPurchased();
            //uiItem.OnItemSelect(index, OnItemSelected);

            //Add purchased item to Shop Data
            GameDataManager.AddPurchasedClothing(index);

        }
        else
        {
            //No enough coins..
            NoCoinsAnim.SetTrigger("NoCoins");
        }
    }

    void OnChestPurchased(int index)
    {
        Chest chest = chestsDB.GetChest(index);
        ItemUI uiItem = GetChestUI(index);

        if (GameDataManager.CanSpendCoins(chest.price))
        {
            //Proceed with the purchase operation
            GameDataManager.SpendCoins(chest.price);

            //Update Coins UI text
            GameSharedUI.Instance.UpdateCoinsUIText();

            //Add purchased item to Shop Data
            //GameDataManager.AddPurchasedTool(index);

        }
        else
        {
            //No enough coins..
            NoCoinsAnim.SetTrigger("NoCoins");
        }
    }
    ItemUI GetToolUI(int index)
    {
        return ShopToolsContainer.GetChild(index+1).GetComponent<ItemUI>();
    }
    ItemUI GetClothingUI(int index)
    {
        return ShopClothingContainer.GetChild(index+1).GetComponent<ItemUI>();
    }
    ItemUI GetChestUI(int index)
    {
        return ShopChestsContainer.GetChild(index + 1).GetComponent<ItemUI>();
    }





}
