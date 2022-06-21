using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float vida;
    public Slider slider;

    private float vidamaxima;
    private float porcentajevida;

    private void Start()
    {
        vidamaxima = vida;
    }

    private void Update()
    {
        porcentajevida = vida / vidamaxima;
        slider.value = porcentajevida;
        if(vida <= 0)
        {
            vida = vidamaxima;
            SceneManager.LoadScene("Perdiste");
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
    }

}
