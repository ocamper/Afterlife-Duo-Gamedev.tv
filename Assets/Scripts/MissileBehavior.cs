using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private AudioSource explodesfx;
    [SerializeField] private GameObject pointLight;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("MissileIgnore"))
            StartCoroutine(beginExplode());
    }

    private IEnumerator beginExplode()
    {
        Destroy(pointLight);
        explodesfx.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
