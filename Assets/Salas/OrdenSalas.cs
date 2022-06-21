using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrdenSalas : MonoBehaviour
{
    float timer;

    public GameObject[] SalasB;

    public GameObject[] SalasT;

    public GameObject[] SalasL;

    public GameObject[] SalasR;

    public GameObject cerrado;

    public List<GameObject> lista; 

    public GameObject enemigo;

    public Text Timer;

    void Update()
    {
        timer += Time.deltaTime;

        Timer.text = (Mathf.FloorToInt(timer)).ToString();

        if (lista.Count == 0)
        {
            SceneManager.LoadScene("Ganaste");
        }

        
    }
}
