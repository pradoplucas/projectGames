using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieFall : MonoBehaviour
{
    private GameObject cameraPlayer;
    private Rigidbody2D rbd;
    private SpriteRenderer sprite;
    private CapsuleCollider2D colEnemie;
    public LayerMask ground;
    private Animator ani;
    private float velocidade;
    private int count = 0, count2 = 0;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        colEnemie = GetComponent<CapsuleCollider2D>();
        ani = GetComponent<Animator>();
        velocidade = 0;
        ani.SetBool("falling", true);
        rbd.gravityScale = 0;
        cameraPlayer = GameObject.FindWithTag ("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2 (velocidade, rbd.velocity.y); 
        falling();
        startFall();
    }

    private void OnTriggerEnter2D(Collider2D col){
        //if(col.tag == "Bar"){ 
            sprite.flipX = !sprite.flipX;
            velocidade *= -1;
        //}
    }

    private void falling(){
        if(colEnemie.IsTouchingLayers(ground) && count == 0){
            ani.SetBool("falling", false);
            count = 1;
        }
    }

    private void startFall(){
        
        if(cameraPlayer.transform.position.x > 34f && count2 == 0){
            rbd.gravityScale = 1;
            velocidade = -2f;
            count2 = 1;
        }
    }
}
