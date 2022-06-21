using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public int Damage;

    void Start()
    {
        Destroy(gameObject, 1);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Jugador>().TakeDamage(Damage);
        }

    }
}
