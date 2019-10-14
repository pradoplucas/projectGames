using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1 : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator ani;
    private SpriteRenderer sprite;
    public float velocidade, forca;
    private BoxCollider2D boxPipe;
    private PolygonCollider2D polDino;
    private CircleCollider2D circleDino;
    public LayerMask ground;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 5f;
        forca = 320f;
        rbd = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        circleDino = GetComponent<CircleCollider2D>();
        polDino = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        moverPular();

        if (Input.GetKeyDown (KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicio");
            
    }

    void mover(){
        rbd.velocity = new Vector2 (Input.GetAxis("Horizontal") * velocidade, rbd.velocity.y);
        ani.SetFloat("velX", Mathf.Abs(rbd.velocity.x));
        sprite.flipX = (rbd.velocity.x < 0);
    }

    void moverPular(){
        if((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && circleDino.IsTouchingLayers(ground)){
            rbd.AddForce(Vector2.up * forca);
        } else if((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S))){
            rbd.AddForce(Vector2.down * forca);
        } 
        ani.SetBool("pula", !circleDino.IsTouchingLayers(ground));
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Baixo" || col.tag == "Cacto"){
            circleDino.isTrigger = true;
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicio");
        } else if(col.tag == "Cima"){
            Destroy(col.transform.parent.gameObject);
        } else if(col.tag == "End")
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game3");
    }

    private void OnTriggerStay2D(Collider2D col){
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && col.tag == "Pipe"){
            boxPipe = col.GetComponent<BoxCollider2D>();
            boxPipe.size = new Vector2(0, 0);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game2");
            
            //Vector3 target = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
            //transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        }    
    }
}
