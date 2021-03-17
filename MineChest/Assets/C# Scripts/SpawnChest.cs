using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    [SerializeField]
    private GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
    //Spawns randomly everytime game starts once       
    Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(chest, new Vector3(Random.Range(-50f, 50f), Random.Range(-35f,35f), 0f), Quaternion.identity);
    }
}
