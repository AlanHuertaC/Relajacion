using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala del tiempo del reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private Text myText;
    private float TiempoFrameConTiempoScale = 0f;
    public float tiempoMostrarEnSegundos = 0F;
    private float escalaDeTiempoPausar, escalaDeTiempoInicial;
    private bool EstaPausado = false;

    // Start is called before the first frame update
    void Start()
    {
        BD bd = GameObject.Find("BD").GetComponent<BD>();
        int tiempoBD = int.Parse(bd.tiempoBD);
        tiempoInicial = tiempoBD * 60; // minutos
        //Escala de Tiempo Original
        escalaDeTiempoInicial = escalaDeTiempo;
        myText = GetComponent<Text>();
        tiempoMostrarEnSegundos = tiempoInicial;
        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFrameConTiempoScale = Time.deltaTime * escalaDeTiempo;
        tiempoMostrarEnSegundos -= TiempoFrameConTiempoScale; //- para que cuente hacia atras
        ActualizarReloj(tiempoMostrarEnSegundos);
    }

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        //if (tiempoEnSegundos < 180f)
        //{
            int minutos = 0;
            int segundos = 0;
            int milisegundos = 0;
            string textoDelReloj;

            if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

            minutos = (int)tiempoEnSegundos / 60;
            segundos = (int)tiempoEnSegundos % 60;
            milisegundos = (int)((tiempoEnSegundos * 10) % 10);

            textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00") + "." + milisegundos.ToString("0");
            myText.text = textoDelReloj;
        //}
    }
}
