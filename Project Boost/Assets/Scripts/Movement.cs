using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbodyPlayer.AddRelativeForce(Vector3.up);
        }
    }

    private static void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("a");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("d");
        }
    }
}
