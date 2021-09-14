using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPelotas : MonoBehaviour
{
    public GameObject Plano;  
    public GameObject[] Pelotas;  
 
    Vector3 pos;
    
    void Start()
    {        
        for(int i = 0; i < 3; i++)
            {
                SpawnBalls();
                Instantiate(Pelotas[2],pos,Quaternion.identity);
                Debug.Log("Pelota Verde:" + (i+1));               
            }   
        for(int e = 0; e < 2; e++)
            {
                SpawnBalls();
                Instantiate(Pelotas[1],pos,Quaternion.identity);
                Debug.Log("Pelota Amarilla:" + (e+1));               
            } 
        SpawnBalls();
        Instantiate(Pelotas[0],pos,Quaternion.identity);
    }

    void Update()
    {    
        if (Control.crearVerde)
        {
            SpawnBalls();
            Instantiate(Pelotas[2],pos,Quaternion.identity);
            Control.crearVerde=false; 
        }
        if (Control.crearAmarilla)
        {
            SpawnBalls();
            Instantiate(Pelotas[1],pos,Quaternion.identity);
            Control.crearAmarilla=false;
        }
        if (Control.crearRoja)
        {
            SpawnBalls();
            Instantiate(Pelotas[0],pos,Quaternion.identity);
            Control.crearRoja=false;
        }
    }   

    private void SpawnBalls()
    {
        float areaZ = (Plano.GetComponent<Renderer>().bounds.size.z) / 2;
        float areaX = (Plano.GetComponent<Renderer>().bounds.size.x) / 2;  
        float x = Random.Range(-areaX, areaX);
        float z = Random.Range(areaZ, -areaZ);
        pos =  new Vector3(x, 3f, z);                  
    }


   }
