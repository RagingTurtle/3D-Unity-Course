using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float xValue = 0;

    float yValue = 0;

    float zValue = 0;
    [SerializeField] float step = 0.01f;

    void Start()
    {
    }

    void Update()
    {
        xValue = Input.GetAxis("Horizontal") * step;
        zValue = Input.GetAxis("Vertical") * step;
        transform.Translate(xValue, yValue, zValue);
    }
}
