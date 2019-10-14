using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    public GameObject ground;
    private GameObject cameraPlayer;
    private float fator = 3, tam = 108.4f;

    // Start is called before the first frame update
    void Start()
    {
        cameraPlayer = GameObject.FindWithTag ("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraPlayer.transform.position.x > (fator * tam - 30f)){
            Vector2 pos = new Vector2(fator * tam, 0);
            Instantiate(ground, pos, Quaternion.identity);
            fator++;
        }
    }
}
