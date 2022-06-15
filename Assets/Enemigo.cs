using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int vida;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        vida -= damage;
        Debug.Log("Ouchie");
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
