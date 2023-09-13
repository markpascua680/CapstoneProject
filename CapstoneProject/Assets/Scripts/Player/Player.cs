using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    public bool isSprinting;
    private Vector2 input;
    private float acceleration = 1.0001f;
    private float topSpeed = 0.5f; //boots = 0.025 
    private float sprintSpeed = 0.75f;
    private float movementTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        movementTime += Time.deltaTime;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Run"))
        {
            topSpeed = sprintSpeed;
            isSprinting = true;
            //movementTime = 0.15f;
        } 
        else {
            /*            if (isSprinting == true)
                        {
                            movementTime = 1.0f;
                        }*/
            topSpeed = 0.5f;
            isSprinting = false;
        }
        if (input != Vector2.zero)
        {
            isMoving = true;
            if (moveSpeed < topSpeed)
            {
                moveSpeed = acceleration * movementTime;
            }
            else
            {
                moveSpeed = topSpeed;
            }
            var targetPos = transform.position;
            targetPos.x = targetPos.x + moveSpeed * input.x;
            targetPos.y = targetPos.y + moveSpeed * input.y;
            transform.position = targetPos;
            Debug.Log("Position = " + targetPos.x + " " + targetPos.y);
            Debug.Log("timer = " + movementTime);
        }
        else {
            isMoving = false;
            movementTime = 0;
            moveSpeed = 0;
        }


    }

}
