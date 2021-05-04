using System.Collections.Generic;
//Player Data Holder
[System.Serializable]
public class PlayerData
{
    public int coins = 0;
}
//Shop Data Holder
[System.Serializable]
public class ToolItemShopData
{
    public List<int> purchasedToolsIndexes = new List<int>();
}//Shop Data Holder
[System.Serializable]
public class ClothingItemShopData
{
    public List<int> purchasedClothingsIndexes = new List<int>();
}

public static class GameDataManager
{
    static PlayerData playerData = new PlayerData();
    static ToolItemShopData toolItemShopData = new ToolItemShopData();
    static ClothingItemShopData clothingItemShopData = new ClothingItemShopData();
    static GameDataManager()
    {
        LoadPlayerData();
        LoadToolsShopData();
        LoadClothingsShopData();
    }

    public static int GetCoins()
    {
        return playerData.coins;
    }

    public static void AddCoins(int amount)
    {
        playerData.coins += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoins(int amount)
    {
        return (playerData.coins >= amount);
    }

    public static void SpendCoins(int amount)
    {
        playerData.coins -= amount;
        SavePlayerData();
    }

    static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>("player-data.txt");
        UnityEngine.Debug.Log("<color=green>[PlayerData] Loaded.</color>");
    }

    static void SavePlayerData()
    {
        BinarySerializer.Save(playerData, "player-data.txt");
        UnityEngine.Debug.Log("<color=magenta>[PlayerData] Saved.</color>");
    }
    //ToolsShopDataMethods
    public static void AddPurchasedTool(int toolIndex)
    {
        toolItemShopData.purchasedToolsIndexes.Add(toolIndex);
        SaveToolsShopData();
    }

    public static List<int> GetAllPurchasedTools()
    {
        return toolItemShopData.purchasedToolsIndexes;
    }

    public static int GetPurchasedTool(int index)
    {
        return toolItemShopData.purchasedToolsIndexes[index];
    }
    static void LoadToolsShopData()
    {
        toolItemShopData = BinarySerializer.Load<ToolItemShopData>("tools-shop-data.txt");
        UnityEngine.Debug.Log("<color=green>[ToolsShopData] Loaded.</color>");
    }

    static void SaveToolsShopData()
    {
        BinarySerializer.Save(toolItemShopData, "tools-shop-data.txt");
        UnityEngine.Debug.Log("<color=magenta>[ToolsShopData] Saved.</color>");
    }
    //ClothingShopDataMethods
    public static void AddPurchasedClothing(int clothingIndex)
    {
        clothingItemShopData.purchasedClothingsIndexes.Add(clothingIndex);
        SaveClothingsShopData();
    }

    public static List<int> GetAllPurchasedClothings()
    {
        return clothingItemShopData.purchasedClothingsIndexes;
    }

    public static int GetPurchasedClothing(int index)
    {
        return clothingItemShopData.purchasedClothingsIndexes[index];
    }
    static void LoadClothingsShopData()
    {
        clothingItemShopData = BinarySerializer.Load<ClothingItemShopData>("clothings-shop-data.txt");
        UnityEngine.Debug.Log("<color=green>[ClothingsShopData] Loaded.</color>");
    }

    static void SaveClothingsShopData()
    {
        BinarySerializer.Save(clothingItemShopData, "clothings-shop-data.txt");
        UnityEngine.Debug.Log("<color=magenta>[ClothingsShopData] Saved.</color>");
    }
}
