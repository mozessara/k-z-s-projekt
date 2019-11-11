using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    private bool jump = false;
    Rigidbody2D rb;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        if(horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if(horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        if(Input.GetButtonDown("Jump")) jump = true;
    }
    private void FixedUpdate(){
        Moving(horizontalMove, jump);
    }
    void Moving(float movement, bool canJump){
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        //ITT
    }
}
