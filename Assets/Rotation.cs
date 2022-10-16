using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;

    // Update is called once per frame
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (cam.enabled)
        {
            cam.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
        }
    }
}
