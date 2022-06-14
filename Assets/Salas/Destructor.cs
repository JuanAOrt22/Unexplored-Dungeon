using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
            Destroy(other.gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}
