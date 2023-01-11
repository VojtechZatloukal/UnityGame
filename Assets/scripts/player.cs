using Assets.InterFaces;
using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour, IHittable
{

    public Rigidbody2D RigidBody;
    public Camera Cam;
    private bool alive = true;

    Vector2 movement;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "end")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
    
    
}

    public GameObject effect;
    public void GotShot()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        
    }
}
