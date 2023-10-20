using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Plane : Vehicles
{
    private Rigidbody planeRb;
    private float noseTiltSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        //ENCAPSULATION
        HorsePower = 7000f;
        TurnSpeed = 50f;

        planeRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isInPlane)
        {
            //INHERITANCE
            //POLYMORPHISM
            //ABSTRACTION
            MoveVehicle(planeRb, Vector3.back);

            //ABSTRACTION
            TiltPlane();

            if (Input.GetKeyDown(KeyCode.F))
            {
                //ABSTRACTION
                ExitPlane();
            }
        }
    }

    private void TiltPlane()
    {
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * noseTiltSpeed);
        }

        else if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * noseTiltSpeed);

        }

    }

    private void ExitPlane()
    {
        Vector3 exitPosition = CalculateExitPosition();

        playerScript.transform.position = exitPosition;
        playerScript.isInPlane = false;
        playerScript.isOnFoot = true;
        playerScript.gameObject.SetActive(true);


    }
}
