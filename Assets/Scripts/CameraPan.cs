using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public float panSpeed = 0.5f; // Speed of camera panning
    public float gridHeight = 100; // Height of the grid

    private float originalYPosition; // Original Y position of the camera

    void Start()
    {
        originalYPosition = transform.position.y; // Store the original Y position of the camera
    }

    void Update()
    {
        // Calculate the new position of the camera
        Vector3 newPosition = transform.position + Vector3.up * panSpeed * Time.deltaTime;

        // Check if the camera reaches the end of the grid
        if (newPosition.y >= originalYPosition + gridHeight)
        {
            // Reset the camera position to the bottom of the grid
            newPosition.y = originalYPosition;
        }

        // Update the camera's position
        transform.position = newPosition;
    }


}
