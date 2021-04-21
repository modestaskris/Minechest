using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Camera minimap;
    // Start is called before the first frame update
    void Start()
    {
        minimap = GetComponent<Camera>();
        minimap.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("m"))
        {
            minimap.enabled = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            minimap.enabled = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        }

    }
}
