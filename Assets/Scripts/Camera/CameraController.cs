using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void MoveCameraToCoord(Vector2Int coord)
    {
        transform.localPosition = new Vector3(coord.x, coord.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
