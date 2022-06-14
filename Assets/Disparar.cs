using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparar : MonoBehaviour
{
    public GameObject Bala;

    public float fuerzaDelDisparo, fuerzaarriba;

    public float Cadencia, Dispersión, TiempoDeRecarga, TiempoEntreDisparos;
    public int TamañoDeLaRecamara, BalasPorDisparo;
    public bool MantenerPresionado;
    int BalasRestantes, balasdisparadas;

    bool m_disparando, m_listoparadisparar, m_recargando, allowInvoke;

    public Camera fps;
    public Transform PuntoDeAtaque;

    public GameObject particulasDisparo;
    public Text municionui;
    
    // Start is called before the first frame update
    void Start()
    {
        BalasRestantes = TamañoDeLaRecamara;
        m_listoparadisparar = true;
        allowInvoke = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

        if(municionui != null)
        {
            municionui.text = ((BalasRestantes / BalasPorDisparo)).ToString() + " / " + ((TamañoDeLaRecamara / BalasPorDisparo)).ToString();
        }
    }

    void MyInput()
    {
        if (MantenerPresionado)
        {
            m_disparando = Input.GetKey(KeyCode.F);
        }
        else
        {
            m_disparando = Input.GetKeyDown(KeyCode.F);
        }

        if (m_listoparadisparar && m_disparando && !m_recargando && BalasRestantes > 0)
        {
            balasdisparadas = 0;

            Dispararr();
        }

        if (Input.GetKeyDown(KeyCode.R) && BalasRestantes < TamañoDeLaRecamara && !m_recargando)
        {
            recargando();
        }

        if (m_listoparadisparar && m_disparando && BalasRestantes <= 0 && !m_recargando)
        {
            recargando();
        }
    }

    private void Dispararr()
    {
        m_listoparadisparar = false;

        Debug.Log("Disparo");

        Ray ray = fps.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 Target;
        if (Physics.Raycast(ray, out hit))
        {
            Target = hit.point;
        }
        else
        {
            Target = ray.GetPoint(75);
        }

        Vector3 direccionSinDispersion = Target - PuntoDeAtaque.position;

        float x = Random.Range(-Dispersión, Dispersión);
        float y = Random.Range(-Dispersión, Dispersión);

        Vector3 direccionConDispersion = direccionSinDispersion + new Vector3(x, y, 0);

        GameObject BalaActual = Instantiate(Bala, PuntoDeAtaque.position, Quaternion.identity);

        BalaActual.transform.forward = direccionConDispersion.normalized;

        BalaActual.GetComponent<Rigidbody>().AddForce(direccionConDispersion.normalized * fuerzaDelDisparo, ForceMode.Impulse);
        BalaActual.GetComponent<Rigidbody>().AddForce(fps.transform.up * fuerzaarriba, ForceMode.Impulse);

        BalasRestantes--;
        balasdisparadas++;

        if(particulasDisparo != null)
        {
            GameObject particulas = Instantiate(particulasDisparo, PuntoDeAtaque.position, Quaternion.identity);
            Destroy(particulas, TiempoEntreDisparos+0.1f);
        }
        if(allowInvoke)
        {
            Invoke("ResetShot", TiempoEntreDisparos);
            allowInvoke = false;
        }

        if (balasdisparadas < BalasPorDisparo && BalasRestantes > 0)
        {
            Invoke("Dispararr", TiempoEntreDisparos);
        }


    }

    void ResetShot()
    {
        m_listoparadisparar = true;
        allowInvoke = true;
    }

    void recargando()
    {
        m_recargando = true;
        Invoke("TerminarRecarga", TiempoDeRecarga);
    }

    void TerminarRecarga()
    {
        BalasRestantes = TamañoDeLaRecamara;
        m_recargando = false;
    }
}
