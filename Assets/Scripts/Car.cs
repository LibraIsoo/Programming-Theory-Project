using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Car : Vehicles
{
    private Rigidbody carRb;
    // Start is called before the first frame update
    void Start()
    {
        //ENCAPSULATION
        HorsePower = 3000f;
        TurnSpeed = 50f;

        carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isInCar)
        {
            //INHERITANCE
            //POLYMORPHISM
            //ABSTRACTION
            MoveVehicle(carRb, Vector3.up);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //ABSTRACTION
                ExitCar();
            }
        }
    }

    private void ExitCar()
    {
        Vector3 exitPosition = CalculateExitPosition();

        playerScript.transform.position = exitPosition;
        playerScript.isInCar = false;
        playerScript.isOnFoot = true;
        playerScript.gameObject.SetActive(true);
    }

}
