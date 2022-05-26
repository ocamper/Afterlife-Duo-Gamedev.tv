using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField] private ButtonPlayer[] playerButtons;
    [SerializeField] private ButtonGhost[] ghostButtons;
    [SerializeField] private ButtonUniversal[] universalButtons;

    private int playerActiveCount;
    private int ghostActiveCount;
    private int universalActiveCount;

    private int test;

    [SerializeField] private SpriteRenderer rend;
    private BoxCollider2D coll;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        foreach (ButtonPlayer plButton in playerButtons)
        {
            if (plButton.buttonActive)
                playerActiveCount++;
        }

        foreach (ButtonGhost ghButton in ghostButtons)
        {
            if (ghButton.buttonActive)
                ghostActiveCount++;
        }

        foreach (ButtonUniversal uniButton in universalButtons)
        {
            if (uniButton.buttonActive)
                universalActiveCount++;
        }


        if (playerActiveCount == playerButtons.Length && ghostActiveCount == ghostButtons.Length && universalActiveCount == universalButtons.Length)
        {
            rend.enabled = false;
            coll.enabled = false;
        }
        else
        {
            rend.enabled = true;
            coll.enabled = true;
        }

        playerActiveCount = 0;
        ghostActiveCount = 0;
        universalActiveCount = 0;
    }
}
