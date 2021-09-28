using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Movement movement;
    float mouseSensitivity = 3f;
    // Use this for initialization
    void Start () {
        movement = GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void Update () {
        doMovement();
        doRotate();
    }

    void doMovement()
    {
        Quaternion rotY = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Vector3 v = Input.GetAxis("Vertical") * (rotY * Vector3.forward)
            + Input.GetAxis("Horizontal") * (rotY * Vector3.right);

        movement.move(v);
    }

    void doRotate()
    {
        movement.rotate(
            -mouseSensitivity * Input.GetAxis("Mouse Y"),
            mouseSensitivity * Input.GetAxis("Mouse X")
            );
    }
}
