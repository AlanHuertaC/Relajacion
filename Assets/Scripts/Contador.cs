using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    // Start is called before the first frame update
    public Text contadorText;
    int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void contar(){
        count = int.Parse(contadorText.text) + 1;
        contadorText.text = count.ToString();
        
    }
}
