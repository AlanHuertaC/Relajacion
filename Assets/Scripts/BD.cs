using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BD : MonoBehaviour
{
    // Start is called before the first frame update
    public string idPaciente;
    public string idEspecialista;
    public string tiempoBD;
    public string[] eyes = new string[2];
    void Awake()
    {
        ConsultasSQL sql = new ConsultasSQL();
        string[] data = sql.getAngleEyes();
    
        eyes[0] = data[0];
        eyes[1] = data[1];

        idPaciente = data[2];
        idEspecialista = data[3];
        tiempoBD = data[4];

        //Debug.Log(eyes[0] + " " +eyes[1] + " " + idPaciente + " " + idEspecialista + " " + tiempoBD);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
