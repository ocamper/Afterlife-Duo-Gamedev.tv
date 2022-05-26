using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGhost : MonoBehaviour
{
    public bool buttonActive;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource pressSfx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            buttonActive = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            buttonActive = false;
        }
    }

    private void Update()
    {
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
