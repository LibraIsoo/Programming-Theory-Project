using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    private float horsePower;
    private float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public Player playerScript;

    protected Vector3 CalculateExitPosition()
    {
        // Calculate the exit position from vehicle based on the local coordinates
        //Allowing me to always exit vehicle on driver side
        return transform.TransformPoint(Vector3.left * 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ENCAPSULATION
    protected virtual float HorsePower
    { 
        get { return horsePower; } 
        set { horsePower = value; }
    }

    //ENCAPSULATION
    protected virtual float TurnSpeed
    {
        get { return turnSpeed; }
        set { turnSpeed = value; }
    }
    public virtual void MoveVehicle(Rigidbody rb, Vector3 rotationAxis)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Moves car forward or backwards depending on input
        rb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

        //Rotates vehicle left or right depending on input
        //Use Vector3.up for car and vector3.back for plane
        transform.Rotate(rotationAxis * Time.deltaTime * turnSpeed * horizontalInput);

    }

}
