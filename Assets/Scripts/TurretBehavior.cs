using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private GameObject fPoint;
    [SerializeField] private GameObject missile;
    [SerializeField] private AudioSource turretsfx;
    [SerializeField] private Animator anim;

    public bool generatingMissile;

    public IEnumerator beginShot()
    {
        generatingMissile = true;
        anim.SetTrigger("plDetected");
        yield return new WaitForSeconds(2);

        Instantiate(missile, fPoint.transform.position, fPoint.transform.rotation);
        turretsfx.Play();
        generatingMissile = false;
    }
}
