using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionar : MonoBehaviour
{
    public Vector3 RotateVector;

    void Update()
    {
        transform.Rotate(RotateVector * Time.deltaTime);
    }
}
