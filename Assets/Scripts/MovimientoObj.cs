using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovimientoObj : MonoBehaviour
{
    // Start is called before the first frame update
    public int no_consecutivo = 0;
    public int no_consecutivo_profundidad = 0;
    public int no_consecutivo_color = 0;
    public GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movimiento()
    {

        int aleatorio = Random.Range(0, 5);

        while (aleatorio == no_consecutivo)
        {
            aleatorio = Random.Range(0, 5);
        }
        no_consecutivo = aleatorio;

        int aleatorio_profundidad = Random.Range(-6, 2);

        while (aleatorio_profundidad == no_consecutivo_profundidad)
        {
            aleatorio_profundidad = Random.Range(-6, 2);
        }
        no_consecutivo_profundidad = aleatorio_profundidad;
        //Debug.Log(aleatorio_profundidad);
        //aleatorio_profundidad = 0; //sin generar un aleatorio de profundidad 
        /*Colores aleatorios*/
        Color[] Colores = { Color.red, Color.blue, new Color(0.8f, 0.1f,0.9f) };
        int aleatorio_color = Random.Range(0, 3);

        while (aleatorio_color == no_consecutivo_color)
        {
            aleatorio_color = Random.Range(0, 3);
        }
        no_consecutivo_color = aleatorio_color;

        switch (aleatorio)
        {
            case 0:
                obj.transform.position = new Vector3(0f, 12.2f, 5.4f + aleatorio_profundidad);
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Colores[aleatorio_color]);
                break;
            case 1:
                obj.transform.position = new Vector3(4.6f, 7.8f, 5.4f + aleatorio_profundidad);
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Colores[aleatorio_color]);
                break;
            case 2:
                obj.transform.position = new Vector3(0f, 3.3f, 5.4f + aleatorio_profundidad);
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Colores[aleatorio_color]);
                break;
            case 3:
                obj.transform.position = new Vector3(-4.6f, 7.8f, 5.4f + aleatorio_profundidad);
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Colores[aleatorio_color]);
                break;
            case 4:
                obj.transform.position = new Vector3(0f, 7.8f, 5.4f + aleatorio_profundidad);
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", Colores[aleatorio_color]);
                break;
        }
    }
}
