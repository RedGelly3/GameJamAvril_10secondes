using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementSanglier : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D animalBody;
    [SerializeField]
    private float walkingSpeed = 5.0f;
    [SerializeField]
    private float jumpPower = 3.50f;

    private void Awake()
    {
        player = gameObject.transform;
        if (transform.parent is not null)
        {
            player = gameObject.transform.parent.transform;
        }

        gameObject.transform.position = player.position;

        animalBody = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        Mouvement();

    }

    void Mouvement()
    {
        //vitesse - InputVelocity 

        if (Input.GetKeyDown(KeyCode.W)) //up key  
        {
            // TODO => if grounded : 
            animalBody.AddForce(Vector3.up * jumpPower * 100);
        }
        if (Input.GetKey(KeyCode.S)) //down key 
        {

        }
        if (Input.GetKey(KeyCode.D)) // Right key 
        {
            print("moving");
            player.transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime, Space.World);
            animalBody.position = player.position;
            //animalBody.AddForce(Vector3.right * walkingSpeed * 100);

        }
        if (Input.GetKeyUp(KeyCode.D)) // Right key 
        {

            //animalBody.AddForce(-Vector3.right * walkingSpeed * 100);

        }

        if (Input.GetKey(KeyCode.A)) // Left key
        {
            //animalBody.AddForce(Vector3.left * walkingSpeed * 100);
            player.transform.Translate(Vector3.left * walkingSpeed * Time.deltaTime, Space.World);
            animalBody.position = player.position;
        }
        if (Input.GetKeyUp(KeyCode.A)) // Right key 
        {

            //animalBody.AddForce(-Vector3.left * walkingSpeed * 100);

        }
        player.position= animalBody.position ;
        gameObject.transform.position = player.position;

    }
}