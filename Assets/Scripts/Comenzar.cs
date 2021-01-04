using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comenzar : MonoBehaviour
{
    public Image PanelPuntuacion;
    public Image PanelInstrucciones;

    // Start is called before the first frame update

    void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comienzo()
    {
        PanelPuntuacion.gameObject.SetActive(true);
        PanelInstrucciones.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
