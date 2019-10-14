using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDinoGame3 : MonoBehaviour
{
    public Transform dino;
    private float altura, largura;

    void Start(){
        altura = Camera.main.orthographicSize; //Captura a altura e salva em "altura"..
        largura = altura * Camera.main.aspect; //Calculo abaixo..
    }

    void FixedUpdate()
    {
        transform.position = new Vector3 (dino.position.x + 6f, 0, transform.position.z);
        if(transform.position.x < 0)
            transform.position = new Vector3 (0, 0, transform.position.z);   
    }
}
