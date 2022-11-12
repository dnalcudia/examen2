using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Area2")
        {
            Vector3 playerPosition = new Vector3(52.99f, 6.73f, 0);
            this.transform.position = playerPosition;
            cam.backgroundColor = Color.black;
        }

        if (other.gameObject.tag == "Area3")
        {
            Vector3 playerPosition = new Vector3(23.59f, 27.5f, 0);
            this.transform.position = playerPosition;
            cam.backgroundColor = Color.red;
        }
    }
}
