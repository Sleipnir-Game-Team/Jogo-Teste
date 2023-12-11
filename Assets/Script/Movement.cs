using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float hMovement = 0; //Movimento horizontal

    [SerializeField] private float hSpeed; //Velocidade horizontal

    [SerializeField] private float maxJumpHeight;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float maxJumps;

    private float jumps = 0;
    private float jumpHeight;
    private bool jumping;
    private bool falling;
    private bool onGround;

    // Chamado uma vez por frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0){
            hMovement = hSpeed;
        } else if(Input.GetAxisRaw("Horizontal") < 0){
            hMovement = -hSpeed;
        } else{
            hMovement = 0;
        }

        if(Input.GetAxisRaw("Jump") == 1 && jumps < maxJumps){
            jumping = true;
            jumps += 1;
        }
    }

    // Chamado em intervalos fixos de tempo
    void FixedUpdate()
    {
        transform.position += new Vector3(hMovement * Time.fixedDeltaTime,0,0);
        if(jumping){
            Pular();
        } else if(falling){
            Cair();
        }
    }

    private void Cair()
    {
        if(onGround){
            falling = false;
            jumps = 0;
            return;
        }
        transform.position -= new Vector3(0,fallSpeed * Time.fixedDeltaTime,0);
    }

    void Pular(){
        transform.position += new Vector3(0,jumpSpeed * Time.fixedDeltaTime,0);
        jumpHeight += jumpSpeed * Time.fixedDeltaTime;
        if(jumpHeight >= maxJumpHeight){
            jumping = false;
            falling = true;
            jumpHeight = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            onGround = false;
        }
    }
}
