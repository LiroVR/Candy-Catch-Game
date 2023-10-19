using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public float speed, jumpStrength;
    private bool onGround;
    private PlayerControls pActions;
    private Vector2 moveVector;
    private Rigidbody2D rBody;
    void Awake()
    {
        pActions = new PlayerControls(); //Initializes and assigns the actions
        rBody = GetComponent<Rigidbody2D>(); //Fetches the rigidbody
    }

    void OnEnable()
    {
        pActions.Player.Enable(); //Enables the player action map
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = pActions.Player.Movement.ReadValue<Vector2>(); //Gets the movement data from the Input system
        transform.Translate(Time.deltaTime * speed * moveVector.y * Vector3.forward); //Converts the data to be used in 3D space (changing y for z)
        transform.Translate(Time.deltaTime * speed * moveVector.x * Vector3.right); //Same as above, but responsible for x axis
        if (pActions.Player.Jump.triggered)
        {
            Jump();
        }
        
    }

    void Jump()
    {
        if (onGround)
        {
            rBody.AddForce((Vector2.up * jumpStrength), ForceMode2D.Impulse);
            onGround = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround= true;
        }


    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

}
