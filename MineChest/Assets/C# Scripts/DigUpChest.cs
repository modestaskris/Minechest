using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigUpChest : MonoBehaviour
{
    private SpriteRenderer chestRenderer;
    private BoxCollider2D chestColider;
    private BoxCollider2D playerColider;
    private Animator playerAnimator;
    private Animator chestAnimator;
    private bool moveChest = false;

    private void Start()
    {
        playerColider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();

        chestRenderer = GameObject.Find("Chest").GetComponent<SpriteRenderer>();
        chestColider = GameObject.Find("Chest").GetComponent<BoxCollider2D>();
        chestAnimator = GameObject.Find("Chest").GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        DigChest();
        
        if (Input.GetKey("g") && chestRenderer.enabled && playerColider.bounds.Intersects(chestColider.bounds)) // to open chest, possible only if player intersects chest bounds, press g and chest is digged
        {
            chestAnimator.SetBool("IsOpen", true);
        }


        if (chestAnimator.GetCurrentAnimatorStateInfo(0).IsTag("1") && chestAnimator.GetBool("IsOpen"))
        {
            chestAnimator.SetBool("IsOpen", false);
            moveChest = true;
        }

        if (chestAnimator.GetCurrentAnimatorStateInfo(0).IsTag("2") && moveChest)
        {
            GameObject.Find("Chest").GetComponent<SpawnChest>().isOpened = true;
            moveChest = false;
        }




    }

    void DigChest()
    {
        if (Input.GetKey("f"))
        {
            playerAnimator.SetBool("dig", true);
            if (playerColider.bounds.Intersects(chestColider.bounds))
            {
                chestRenderer.enabled = true;
            }
        }
        else
        {
            playerAnimator.SetBool("dig", false);
        }
    }
}
