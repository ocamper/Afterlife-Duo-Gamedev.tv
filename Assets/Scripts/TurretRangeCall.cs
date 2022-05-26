using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRangeCall : MonoBehaviour
{
    [SerializeField] private GameObject turret;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.Find("missile(Clone)") == null && !turret.GetComponent<TurretBehavior>().generatingMissile)
        {
            StartCoroutine(turret.GetComponent<TurretBehavior>().beginShot());
        }
    }
}
