using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private ButtonPlayer[] playerButtons;
    [SerializeField] private ButtonGhost[] ghostButtons;
    [SerializeField] private ButtonUniversal[] universalButtons;

    [SerializeField] private Animator anim;

    private int playerActiveCount;
    private int ghostActiveCount;
    private int universalActiveCount;

    private int test;

    [SerializeField] private GameObject closedDoor;
    [SerializeField] private AudioSource opensfx;
    [SerializeField] private BoxCollider2D triggerCollide;

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
            anim.SetBool("isOpen", true);
            triggerCollide.enabled = true;
        }
        else
        {
            anim.SetBool("isOpen", false);
            triggerCollide.enabled = false;
        }


        playerActiveCount = 0;
        ghostActiveCount = 0;
        universalActiveCount = 0;
    }

    public void OpenSfx()
    {
        opensfx.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GameObject.Find("Transition").GetComponent<TransitionScript>().activateOut());
        }
    }


}
