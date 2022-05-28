using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacle : MonoBehaviour
{
    [SerializeField] private ButtonPlayer btPlayer;

    float alphaColor = 1;
    bool hasPressed;

    private void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alphaColor);
        if (btPlayer.buttonActive)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            hasPressed = true;
        }

        if(hasPressed)
            alphaColor = Mathf.Lerp(alphaColor, 0f, 0.01f);
    }
}
