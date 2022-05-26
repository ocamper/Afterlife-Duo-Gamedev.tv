using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource respawnSfx;

    private bool firstSpawn;

    public void Awake()
    {
        firstSpawn = true;
        NewPlayer();
    }

    public void NewPlayer()
    {
        Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);
        
        if (!firstSpawn)
             respawnSfx.Play();
        
        firstSpawn = false;
    }

}
