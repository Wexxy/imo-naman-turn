using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{   
    // public Transform target;
    private Vector3 mousePosition;
    private void Start()
    {
        // Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        // transform.position = mousePosition;
        transform.position = new Vector3(-mousePosition.x, mousePosition.y, 0.017f);
    }
}
