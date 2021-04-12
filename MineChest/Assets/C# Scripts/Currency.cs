using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{

    public int lootfromChest;
    public int minCurrencyGained;
    public int maxCurrencyGained;
    private GameObject chest;
    private float chestX;
    private float chestY;
    // Start is called before the first frame update
    void Start()
    {
        chest = GameObject.Find("Chest");
        chestX = chest.transform.position.x;
        chestY = chest.transform.position.y;
        lootfromChest = LootFromChest(minCurrencyGained, maxCurrencyGained);
    }

    // Update is called once per frame
    void Update()
    {
        if (chestX != chest.transform.position.x && chestY != chest.transform.position.y)
        {
            lootfromChest = LootFromChest(minCurrencyGained, maxCurrencyGained);
            chestX = chest.transform.position.x;
            chestY = chest.transform.position.y;
            Debug.Log(lootfromChest);
        }
    }

    public int LootFromChest(int min,int max)
    {
        return Random.Range(min, max);
    }
}
