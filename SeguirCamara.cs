using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform pelota;  // Arrastra la pelota aquí en el Inspector
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - pelota.position;
    }

    void LateUpdate()
    {
        transform.position = pelota.position + offset;
    }
}
