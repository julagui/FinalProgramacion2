using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public float velocidad;   
    public int vidas = 3;
    public float tiempo = 30f;
    public int nivel = 1;
    public int puntos = 0;

    public static int recolectados;
    public static bool crearAmarilla;
    public static bool crearVerde;
    public static bool crearRoja;

    public Vector3 PlayerMovementInput;    
    Rigidbody rb;

    public Text Txttiempo;
    public Text Txtvidas;
    public Text Txtpuntos;
    public Text Txtnivel;

    public Image GameOver;

    void Start()
    {
        GameOver.enabled = false;
        recolectados = 0;
        crearAmarilla=false;
        crearVerde=false;
        crearRoja=false;
        rb = GetComponent<Rigidbody>();
    }
       
    void Update()
    {
        tiempo -= 1* Time.deltaTime;

        Txttiempo.text = "Tiempo: "+tiempo.ToString("0");
        Txtvidas.text = "Vidas: "+vidas;
        Txtpuntos.text = "Puntos: "+puntos;
        Txtnivel.text = "Nivel: "+nivel;

        if (recolectados == 5)
        {
            nivel +=1;
            crearRoja=true;
            tiempo+=15f;
            recolectados = 0;
            Debug.Log("nivel: "+nivel); 
        }
        if (tiempo == 0)
        {
            GameOver.enabled = true;
            
        }
        if (vidas == 0)
        {
            GameOver.enabled = true;
            
        }
    }

    void FixedUpdate() 
    {        
        PlayerMovementInput = new Vector3 (Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput)*velocidad;
        rb.velocity = new Vector3 (MoveVector.x,rb.velocity.y,MoveVector.z);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Amarilla")
        {            
            puntos = puntos +  (15*nivel); 
            Destroy(collision.gameObject);
            crearVerde=true;
            recolectados+=1;
            Debug.Log("Puntos: "+puntos); 
            Debug.Log("recolectados: "+recolectados);     
        }
        if (collision.gameObject.tag == "Verde")
        {            
            puntos = puntos +  (10*nivel);
            Destroy(collision.gameObject); 
            crearAmarilla=true;
            recolectados+=1;
            Debug.Log("Puntos: "+puntos);  
            Debug.Log("recolectados: "+recolectados);                    
        }
        if (collision.gameObject.tag == "Roja")
        {            
            Destroy(collision.gameObject);
            crearRoja=true;
            vidas -= 1;
            Debug.Log("Vidas: "+vidas); 
        }
    }    
}
