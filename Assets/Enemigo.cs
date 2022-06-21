using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemigo : MonoBehaviour
{

    public int vida;
    public float distanciadever = 10f;
    public float fuerzadeldisparo;

    public Transform target;
    public Transform armaenemiga;
    public GameObject BalaEnemiga;

    Quaternion Rotacionmirar;

    NavMeshAgent agent;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            Invoke("Disparar", 1f);
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

    void Disparar()
    {
        Invoke("DispararAlJugador", 1);
    }

    void GirarAlJugador()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Rotacionmirar = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotacionmirar, Time.deltaTime * 5f);
    }

    void DispararAlJugador()
    {
        Ray ray = new Ray(armaenemiga.transform.position, target.transform.position);
        RaycastHit pego;


        Vector3 direccionapegar;
        if(Physics.Raycast(ray, out pego))
        {
            direccionapegar = pego.point;
        }
        else
        {
            direccionapegar = ray.GetPoint(75);
        }
        direccionapegar = direccionapegar - armaenemiga.position;

        GameObject BalaEnemigaClon = Instantiate(BalaEnemiga, armaenemiga.position, Rotacionmirar);
        BalaEnemigaClon.GetComponent<Rigidbody>().AddForce(-direccionapegar * fuerzadeldisparo, ForceMode.Impulse);
    }
}
