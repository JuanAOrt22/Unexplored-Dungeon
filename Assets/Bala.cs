using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public int Damage;
   
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemigo"))
        {
            collider.GetComponent<Enemigo>().TakeDamage(Damage);
        }

    }
}
