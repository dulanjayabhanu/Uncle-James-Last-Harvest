using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform targetTraking;
    public float cameraSmoothParam = 5f;

    Vector3 offest;

    // Start is called before the first frame update
    void Start()
    {
        offest = transform.position - targetTraking.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = targetTraking.position + offest;
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, cameraSmoothParam * Time.deltaTime);
    }
}
