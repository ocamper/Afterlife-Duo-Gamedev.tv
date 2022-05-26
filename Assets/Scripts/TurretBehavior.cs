using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private GameObject fPoint;
    [SerializeField] private GameObject missile;

    public bool generatingMissile;

    public IEnumerator beginShot()
    {
        generatingMissile = true;
        yield return new WaitForSeconds(2);

        Instantiate(missile, fPoint.transform.position, fPoint.transform.rotation);
        generatingMissile = false;
    }
}
