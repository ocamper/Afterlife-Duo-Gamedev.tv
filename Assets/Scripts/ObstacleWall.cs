using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    [SerializeField] private ButtonPlayer[] playerButtons;
    [SerializeField] private ButtonGhost[] ghostButtons;
    [SerializeField] private ButtonUniversal[] universalButtons;

    [SerializeField] private Animator anim;

    private int playerActiveCount;
    private int ghostActiveCount;
    private int universalActiveCount;

    [SerializeField] private BoxCollider2D triggerCollide;
    [SerializeField] private bool shouldCloseAgain;

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
            anim.SetBool("isDeactive", true);
            triggerCollide.enabled = false;
        }
        else if (shouldCloseAgain)
        {
            anim.SetBool("isDeactive", false);
            triggerCollide.enabled = true;
        }


        playerActiveCount = 0;
        ghostActiveCount = 0;
        universalActiveCount = 0;
    }
}
