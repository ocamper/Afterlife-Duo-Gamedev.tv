using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject outScreen;
    [SerializeField] private GameObject stButton;
    [SerializeField] private AudioSource swishSfx;
    [SerializeField] private AudioSource textDoneSfx;
    [SerializeField] private AudioSource titleMusic;
    [SerializeField] private GameObject creditButton;
    [SerializeField] private GameObject creditUi;
    [SerializeField] private AudioSource outroSfx;
    private bool musicPlayed;

    public void OnClick()
    {
        outScreen.SetActive(true);
        outroSfx.Play();
        SceneManager.LoadSceneAsync(1);
    }

    public void SpawnButton()
    {
        stButton.SetActive(true);
        creditButton.SetActive(true);
        if (!musicPlayed)
            titleMusic.Play();

        musicPlayed = true;
    }

    public void WindEffect()
    {
        swishSfx.Play();
    }

    public void newSfx()
    {
        textDoneSfx.Play();
    }

    public void CreditsOn()
    {
        creditUi.SetActive(true);
    }

    public void CreditsOff()
    {
        creditUi.SetActive(false);
    }
}
