using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform traget;

    private void Update()
    {
        transform.position = new Vector3(traget.position.x, traget.position.y, transform.position.z);
    }
}
