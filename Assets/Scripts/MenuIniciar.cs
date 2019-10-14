using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuIniciar : MonoBehaviour
{
    private bool choice = true;
    public Button buttonJogar, buttonSair;
    private ColorBlock buttonJogarColor, buttonSairColor;
    private Color grey = new Vector4(0.9f, 0.9f, 0.9f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        //buttonJogar = GameObject.Find.WithTag("ButtonJogar");
        //buttonJogar = GetComponent<Button>();
        buttonJogarColor = buttonJogar.GetComponent<Button>().colors;
        //buttonSair = GameObject.Find.WithTag("ButtonSair");
        //buttonSair = GetComponent<Button>();
        buttonSairColor = buttonSair.GetComponent<Button>().colors;

        buttonJogarColor.normalColor = grey;
        buttonJogar.colors = buttonJogarColor;
        buttonSairColor.normalColor = Color.white;
        buttonSair.colors = buttonSairColor;
    }

    // Update is called once per frame
    void Update()
    {
        MovMenu(); //AAAAAAAAAAAAAAA
    }

    public void jogar(){
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game1");
    }

    public void sair(){
        Application.Quit();
    }

    void MovMenu(){
        if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)){
            choice = false;
            buttonJogarColor.normalColor = Color.white;
            buttonJogar.colors = buttonJogarColor;
            buttonSairColor.normalColor = grey;
            buttonSair.colors = buttonSairColor;
        } else if(Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)){
            choice = true;
            buttonJogarColor.normalColor = grey;
            buttonJogar.colors = buttonJogarColor;
            buttonSairColor.normalColor = Color.white;
            buttonSair.colors = buttonSairColor;
        } else if(Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space)){
            if(choice) jogar();
            else sair();
        }
    }
}
