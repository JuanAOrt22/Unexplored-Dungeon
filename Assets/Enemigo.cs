using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemigo : MonoBehaviour
{

    public int vida;
    public float distanciadever = 10f;

    public Transform target;
    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void TakeDamage(int damage)
    {
        vida -= damage;
        Debug.Log("Ouchie");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= distanciadever)
        {
            agent.SetDestination(target.position);
        }
        if(distance <= agent.stoppingDistance)
        {
            GirarAlJugador();
        }
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void GirarAlJugador()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion Rotacionmirar = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotacionmirar, Time.deltaTime * 5f);
    }
}
