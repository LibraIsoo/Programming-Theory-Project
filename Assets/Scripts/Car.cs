using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicles
{
    private Rigidbody carRb;
    // Start is called before the first frame update
    void Start()
    {
        HorsePower = 3000f;
        TurnSpeed = 50f;
        carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isInCar)
        {
            MoveVehicle(carRb, Vector3.up);

            if (Input.GetKeyDown(KeyCode.F))
            {
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
