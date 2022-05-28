using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource respawnSfx;
    [SerializeField] private bool searchCinemachine;
    [SerializeField] private bool searchTutorialText;

    private bool firstSpawn;
    private GameObject newPlayerInstance;

    public void Awake()
    {
        firstSpawn = true;
        NewPlayer();
    }

    public void NewPlayer()
    {
        Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);

        if (!firstSpawn)
        {
            respawnSfx.Play();
            if (searchTutorialText)
            {
                GameObject.Find("textMesh_search").GetComponent<TextMesh>().color = new Color(0, 0, 0, 1);
                GameObject.Find("textMesh_search2").GetComponent<TextMesh>().color = new Color(0, 0, 0, 1);
            }
        }

        newPlayerInstance = GameObject.FindGameObjectWithTag("Player");

        if (searchCinemachine)
        {
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayerInstance.transform;
        }
        
        firstSpawn = false;
    }

}
