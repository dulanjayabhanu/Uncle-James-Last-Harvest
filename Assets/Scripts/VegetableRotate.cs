using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableRotate : MonoBehaviour
{
    private float animateSpeed = 150;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(Vector3.up * animateSpeed * Time.deltaTime);
    }
}
