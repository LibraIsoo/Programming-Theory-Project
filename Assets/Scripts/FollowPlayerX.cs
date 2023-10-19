using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform plane;
    public Transform blueCar;
    public Transform player;
    private Vector3 offset;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        offset = new Vector3(0, 5f, -10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerScript.isOnFoot)
        {
            FollowPlayer();
        }

        if (playerScript.isInCar)
        {
            FollowCar();
        }

        if (playerScript.isInPlane)
        {
            FollowPlane();
        }
    }

    private void FollowPlayer()
    {
        // Calculate the desired camera position.
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // Smoothly move the camera to the desired position using Lerp or Slerp.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);

        // Look at the player's position.
        transform.LookAt(player);
    }

    private void FollowCar()
    {
        Vector3 desiredPosition = blueCar.position + blueCar.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);
        transform.LookAt(blueCar);

    }

    private void FollowPlane()
    {
        Vector3 desiredPosition = plane.position + plane.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);
        transform.LookAt(plane);

    }
}
