using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private int speed = 150;
    private float horizontalInput;
    private float verticalInput;
    private float turnSpeed = 100f;

    public float interactionDistance = 5f;
    private Vehicles nearestVehicle = null;

    public bool isOnFoot;
    public bool isInCar = false;
    public bool isInPlane = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        isOnFoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnFoot)
        {
            //ABSTRACTION
            MovePlayer();
            if (Input.GetKeyDown(KeyCode.E))
            {
                //ABSTRACTION
                FindNearestVehicle();
            }
        }

        else
        { gameObject.SetActive(false); }
    }

    public void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

    public void FindNearestVehicle()
    {
        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Vehicle");

        float nearestDistance = interactionDistance;
        nearestVehicle = null;

        foreach (GameObject vehicleObj in vehicles)
        {
            Vehicles vehicle = vehicleObj.GetComponent<Vehicles>();
            if (vehicle != null)
            {
                float distance = Vector3.Distance(vehicleObj.transform.position, transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestVehicle = vehicle;
                }
            }
        }

        if (nearestVehicle != null)
        {
            // You can now interact with the nearest vehicle based on its specific script
            if (nearestVehicle is Car)
            {
                Car car = nearestVehicle as Car;
                isOnFoot = false;
                isInCar = true;
                Debug.Log("Enter Car");
            }
            else if (nearestVehicle is Plane)
            {
                Plane plane = nearestVehicle as Plane;
                Debug.Log("Enter Plane");
                isOnFoot = false;
                isInPlane = true;
            }
        }
    }
}
