using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TextoTiempo;
    public Text Tiempo;
    public Text Puntuacion;
    public Image PanelPuntuacion;

    /*public Image PanelFinal;
    public Text PuntuacionFinal;
    public Text TiempoFinal;*/

    /*Panel Instrucciones*/
    public Image PanelInstrucciones;
    /*Tiempo*/
    float tiempo;
    string tiempotexto;
    void Start()
    {
        tiempo = 0f;
        tiempotexto = Tiempo.text.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tiempotexto = Tiempo.text.ToString();
        /*Para evitar bugs XD*/
        if (tiempotexto.Equals("00:00.0"))
        {
            tiempoFinalizado();

        }
    }

    public void terminar(){
        Time.timeScale = 0; // Se detiene el tiempo
        ConsultasSQL sql = new ConsultasSQL(); 
        CameraSettings camera = GameObject.Find("LeftEye").GetComponent<CameraSettings>();
        string paciente = camera.idPaciente;
        string especialista = camera.idEspecialista;
        //string duracion = Tiempo.text.ToString();
        /*duracion*/
        Reloj reloj = GameObject.Find("Reloj").GetComponent<Reloj>();
        //Debug.Log("Tiempo inicial" + reloj.tiempoInicial);
        int minutos = int.Parse(Tiempo.text.ToString().Substring(0, 2));
        int segundos = int.Parse(Tiempo.text.ToString().Substring(3, 2));
        int mintoseg = minutos * 60;
        int resultado = reloj.tiempoInicial - (mintoseg + segundos);
        //Debug.Log(resultado);
        /*Conversion a string*/
        minutos = (int)resultado / 60;
        segundos = (int)resultado % 60;
        string duracion = minutos.ToString("00") + ":" + segundos.ToString("00");
        Debug.Log(duracion);
        /**/
        string puntuacion = Puntuacion.text.ToString();
        sql.insertTratamiento("Calentamiento",puntuacion,duracion,paciente,especialista);
        
        /*Ocultar los tiempos y el canvas de puntuacion*/
        TextoTiempo.gameObject.SetActive(false);
        //Tiempo.gameObject.SetActive(false);
        Text t = Tiempo.GetComponent<Text>();
        t.color = new Color(1f, 1f, 1f, 0f);
        PanelPuntuacion.gameObject.SetActive(false);
        /*Ocultar figuras para que no se pueda interactuar*/
        /*obj1.gameObject.SetActive(false);
        obj2.gameObject.SetActive(false);
        obj3.gameObject.SetActive(false);*/

        /*Poner el canvas con el puntaje y tiempo*/
       /* PuntuacionFinal.text = "Obtuviste una puntuación de " + Puntuacion.text + " puntos"; 
        TiempoFinal.text = "Tu tiempo final fue de: " + duracion;
        PanelFinal.gameObject.SetActive(true);*/
        
    }

    public void reiniciar(){
        /*PanelFinal.gameObject.SetActive(false);
        /*obj1.gameObject.SetActive(true);
        obj2.gameObject.SetActive(true);*/
       /* obj3.gameObject.SetActive(true);
        obj3.transform.position = new Vector3(-.8f, 1.5f, 4.21f);
        PanelInstrucciones.gameObject.SetActive(true);*/
        Puntuacion.text = "0";
        
    }

    public void tiempoFinalizado()
    {
        ConsultasSQL sql = new ConsultasSQL();
        CameraSettings camera = GameObject.Find("LeftEye").GetComponent<CameraSettings>();
        string paciente = camera.idPaciente;
        string especialista = camera.idEspecialista;

        Reloj reloj = GameObject.Find("Reloj").GetComponent<Reloj>();
        
        int minutos = int.Parse(Tiempo.text.ToString().Substring(0, 2));
        int segundos = int.Parse(Tiempo.text.ToString().Substring(3, 2));
        int mintoseg = minutos * 60;
        int resultado = reloj.tiempoInicial - (mintoseg + segundos);
        /*Conversion a string*/
        minutos = (int)resultado / 60;
        segundos = (int)resultado % 60;
        string duracion = minutos.ToString("00") + ":" + segundos.ToString("00");
        //Debug.Log(duracion);
        /**/
        string puntuacion = Puntuacion.text.ToString();

        reloj.tiempoMostrarEnSegundos = reloj.tiempoInicial;
        Time.timeScale = 0; // Se detiene el tiempo

        sql.insertTratamiento("Calentamiento", puntuacion, duracion, paciente, especialista);

        /*Ocultar los tiempos y el canvas de puntuacion**/
        TextoTiempo.gameObject.SetActive(false);
        //Tiempo.gameObject.SetActive(false);
        Text t = Tiempo.GetComponent<Text>();
        t.color = new Color(1f, 1f, 1f, 0f); // Truco para ocultar el tiempo sin que truene el programa :'v

        //PanelPuntuacion.gameObject.SetActive(false);
        /*Ocultar figuras para que no se pueda interactuar*/
        /*obj1.gameObject.SetActive(false);
        obj2.gameObject.SetActive(false);
        obj3.gameObject.SetActive(false);*/

        /*Poner el canvas con el puntaje y tiempo*/
        /*PuntuacionFinal.text = "Obtuviste una puntuación de " + Puntuacion.text + " puntos";
        TiempoFinal.text = "Tu tiempo final fue de: " + duracion;
        PanelFinal.gameObject.SetActive(true);*/
        PanelPuntuacion.gameObject.SetActive(false);
    }
}
