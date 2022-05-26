using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private float horizontalMove;
    [SerializeField] private float runSpeed;
    private bool jump;
    
    public bool movementAvailable = true;
    [SerializeField] private Transform ghostSpawn;
    [SerializeField] private GameObject ghostPrefab;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float jumpForce;

    [SerializeField] private SpriteRenderer spRend;
    
    [SerializeField] private AudioSource stepsfx;
    [SerializeField] private AudioSource jumpsfx;
    [SerializeField] private AudioSource deathsfx;

    public bool isDead;


    private void Update()
    {
        if (movementAvailable)
        {
            if (Input.GetButtonDown("Jump") && !jump)
                jump = true;

            horizontalMove = Input.GetAxisRaw("Horizontal1") * runSpeed;
        } else
        {
            horizontalMove = 0;
        }

        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(startGhostSpawn());

        if (isDead)
        {
            spRend.sortingLayerName = "Foreground";
            movementAvailable = false;
            controller.enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            gameObject.tag = "DeadPlayer";

            GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawnerScript>().NewPlayer();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
             playerAnim.SetBool("isWalking", true);
        else
             playerAnim.SetBool("isWalking", false);

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        
        jump = false;
    }

    IEnumerator startGhostSpawn()
    {
        movementAvailable = false;
        playerAnim.SetTrigger("isDead");
        spRend.color = new Color(0.2f, 0.2f, 0.2f, 0.7f);
        yield return new WaitForSeconds(2);

        if (GameObject.Find("GhostPlayer(Clone)") != null)
            Destroy(GameObject.Find("GhostPlayer(Clone)"));
       
        Instantiate(ghostPrefab, ghostSpawn.position, ghostSpawn.rotation);
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrigger") && !isDead)
            StartCoroutine(startGhostSpawn());
    }

    public void StepsSfx()
    {
        stepsfx.Play();
    }

    public void JumpSfx()
    {
        jumpsfx.Play();
    }

    public void DeathSfx()
    {
        deathsfx.Play();
    }
}
