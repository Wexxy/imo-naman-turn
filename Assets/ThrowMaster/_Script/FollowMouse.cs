using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        mousePos.z = -.2f;
        Debug.Log(Input.mousePosition);
        transform.position = mousePos;
        Debug.Log(mousePos);
    }
}
