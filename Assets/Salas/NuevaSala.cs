using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevaSala : MonoBehaviour
{

    private OrdenSalas sala;
    // Start is called before the first frame update
    void Start()
    {
        sala = GameObject.FindGameObjectWithTag("Rooms").GetComponent<OrdenSalas>();
        sala.lista.Add(this.gameObject);
    }

}
