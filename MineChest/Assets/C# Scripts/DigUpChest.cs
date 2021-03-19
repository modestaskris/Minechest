using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigUpChest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer;
    [SerializeField]
    private BoxCollider2D chest;
    [SerializeField]
    private BoxCollider2D player;

    // Update is called once per frame
    void Update()
    {
        if (player.bounds.Intersects(chest.bounds))
        {
            renderer.enabled = true;
        }
    }
}
