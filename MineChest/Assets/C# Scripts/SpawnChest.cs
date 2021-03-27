using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    [SerializeField]
    private GameObject chest;
    [SerializeField]
    private SpriteRenderer renderer;

    public bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        //Spawns randomly everytime game starts once       
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOpened) // if chest is digged, it trigers spawn
        {
            Spawn(); // reikia kad sukurtu nauja objekta
            isOpened = false;
        }
        
    }
    /*
    void Spawn() // blogos koordinates
    {
        Vector3 chestLoacation = new Vector3(Random.Range(-50f, 50f), Random.Range(-35f, 35f), 0f);
        chest.transform.position = chestLoacation;
        renderer.enabled = false;
        //Instantiate(chest, new Vector3(Random.Range(-50f, 50f), Random.Range(-35f,35f), 0f), Quaternion.identity);
    }
    */

    void Spawn()
    {
        int area = Random.Range(0, 12); // viso 12 skirtingu plotu, jei reikes plotu foto pavaizduotu zemelapy, imesiu
        if(area == 0) 
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-60, -32), Random.Range(45, 50), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 1)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-58, -43), Random.Range(7, 43), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 2)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-74, -50), Random.Range(0, 9), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 3)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-67, -60), Random.Range(11, 17), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 4)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-37, -2), Random.Range(-8, 17), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 5)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-2, 13), Random.Range(-4, 54), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 6)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-30, -1), Random.Range(16, 39), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 7)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(-25, -1), Random.Range(35, 55), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 8)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(15, 32), Random.Range(-7, 2), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 9)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(32, 45), Random.Range(-11, -6), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 10)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(16, 36), Random.Range(45, 55), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
        else if (area == 11)
        {
            Vector3 chestLoacation = new Vector3(Random.Range(16, 32), Random.Range(36, 44), 0f);
            chest.transform.position = chestLoacation;
            renderer.enabled = false;
        }
    }
}
