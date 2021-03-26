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
    [SerializeField]
    private Animator animator;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey("f"))
        {
            animator.SetBool("dig", true);
            if (player.bounds.Intersects(chest.bounds))
            {
                renderer.enabled = true;
            }
        }
        else
        {
            animator.SetBool("dig", false);
        }

    }
}
