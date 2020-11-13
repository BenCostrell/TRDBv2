using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void CenterCamera(int width, int height)
    {
        transform.localPosition = new Vector3(width / 2f, height / 2f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
