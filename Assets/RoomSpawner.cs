using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;

    private OrdenSalas salas;
    private int rand;
    private int randomenemigo;
    private bool spawned = false;

    void Awake()
    {
        salas = GameObject.FindGameObjectWithTag("Rooms").GetComponent<OrdenSalas>();
        Invoke("Spawn", 0.1f);

    }

    void Spawn()
    {
        randomenemigo = Random.Range(1, 3);
        if (!spawned)
        {
            if (OpeningDirection == 1)
            {
                rand = Random.Range(0, salas.SalasB.Length);
                Instantiate(salas.SalasB[rand], transform.position, salas.SalasB[rand].transform.rotation);
                for (int i = 0; i < randomenemigo; i++)
                {
                    GameObject Enemigo = Instantiate(salas.enemigo, transform.position, Quaternion.identity);
                    salas.lista.Add(Enemigo);
                }
                
            }
            if (OpeningDirection == 2)
            {
                rand = Random.Range(0, salas.SalasT.Length);
                Instantiate(salas.SalasT[rand], transform.position, salas.SalasT[rand].transform.rotation);
                for (int i = 0; i < randomenemigo; i++)
                {
                    GameObject Enemigo =Instantiate(salas.enemigo, transform.position, Quaternion.identity);
                    salas.lista.Add(Enemigo);
                }
            }
            if (OpeningDirection == 3)
            {
                rand = Random.Range(0, salas.SalasL.Length);
                Instantiate(salas.SalasL[rand], transform.position, salas.SalasL[rand].transform.rotation);
                for (int i = 0; i < randomenemigo; i++)
                {
                    GameObject Enemigo = Instantiate(salas.enemigo, transform.position, Quaternion.identity);
                    salas.lista.Add(Enemigo);
                }
            }
            if (OpeningDirection == 4)
            {
                rand = Random.Range(0, salas.SalasR.Length);
                Instantiate(salas.SalasR[rand], transform.position, salas.SalasR[rand].transform.rotation);
                for (int i = 0; i < randomenemigo; i++)
                {
                    GameObject Enemigo = Instantiate(salas.enemigo, transform.position, Quaternion.identity);
                    salas.lista.Add(Enemigo);
                }
            }
        }
        spawned = true;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomSpawn"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Invoke("InstanciarAlgo", 0.1f);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

    void InstanciarAlgo()
    {
        Instantiate(salas.cerrado, transform.position, salas.cerrado.transform.rotation);
    }
}
