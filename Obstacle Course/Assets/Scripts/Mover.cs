using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float xValue = 0;
    public float yValue = 0;
    public float zValue = 0;
    public float step = 0.01f;
    void Start()
    {
    }

    void Update()
    {
                transform.Translate(xValue,yValue,zValue);
                yValue += step;
    }
}
