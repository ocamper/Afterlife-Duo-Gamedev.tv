using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayer : MonoBehaviour
{
    public bool buttonActive;
    private bool isDeadPlayerOn;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource pressSfx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buttonActive = true;
        }

        if (collision.gameObject.tag == "DeadPlayer")
        {
            isDeadPlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buttonActive = false;
        }
    }

    private void Update()
    {
        if (isDeadPlayerOn)
            buttonActive = true;

        if (buttonActive)
            anim.SetBool("isPressed", true);
        else
            anim.SetBool("isPressed", false);
    }

    public void PressSfx()
    {
        pressSfx.Play();
    }
}
