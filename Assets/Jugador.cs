using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    private void TakeDamage(int damage)
    {
        vida -= damage;
    }

}
