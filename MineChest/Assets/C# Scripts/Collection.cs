using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    #region Singlton:Collection
    public static Collection Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion


    //GameObject g;
    //[SerializeField] GameObject CollectionUITemplate;
    [SerializeField] GameObject Map1Coin1UITemplate;
    [SerializeField] GameObject Map1Coin2UITemplate;
    [SerializeField] GameObject Map1Coin3UITemplate;
    [SerializeField] GameObject Map2Coin1UITemplate;
    [SerializeField] GameObject Map2Coin2UITemplate;
    [SerializeField] GameObject Map2Coin3UITemplate;
    [SerializeField] GameObject Map3Coin1UITemplate;
    [SerializeField] GameObject Map3Coin2UITemplate;
    [SerializeField] GameObject Map3Coin3UITemplate;
    // Start is called before the first frame update
    void Start()
    {
        GetAvailableCollectables();
    }

    // Update is called once per frame
    void Update()
    {
        GetAvailableCollectables();
    }

    void GetAvailableCollectables()
    {
        if (Shop.Instance == null)
            return;
        //Map2Coin3UITemplate.SetActive(true);
        for (int i = 0; i < Shop.Instance.collectablesList.Count; i++)
        {
            if (Shop.Instance.collectablesList[i].Collected == false)
                continue;
            int map = Shop.Instance.collectablesList[i].Map;
            int coin = Shop.Instance.collectablesList[i].Possition;
            if (map == 1)
            {
                if (coin == 1)
                    Map1Coin1UITemplate.SetActive(true);
                if (coin == 2)
                    Map1Coin2UITemplate.SetActive(true);
                if (coin == 3)
                    Map1Coin3UITemplate.SetActive(true);
            }
            if (map == 2)
            {
                if (coin == 1)
                    Map2Coin1UITemplate.SetActive(true);
                if (coin == 2)
                    Map2Coin2UITemplate.SetActive(true);
                if (coin == 3)
                    Map2Coin3UITemplate.SetActive(true);
            }
            if (map == 3)
            {
                if (coin == 1)
                    Map3Coin1UITemplate.SetActive(true);
                if (coin == 2)
                    Map3Coin2UITemplate.SetActive(true);
                if (coin == 3)
                    Map3Coin3UITemplate.SetActive(true);
            }
        }
    }
}
