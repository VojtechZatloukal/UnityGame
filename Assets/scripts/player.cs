using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody2D RigidBody;
    public Camera Cam;

    Vector2 movement;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = getInputMovement();
        LookAtMouse();
        

    }

    void FixedUpdate()
    {

        RigidBody.MovePosition(RigidBody.position + movement * Constants.speed * Time.fixedDeltaTime);
    }


    private void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }
   
    private Vector2 getInputMovement()
    {
        
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return input;
        
    }
}
