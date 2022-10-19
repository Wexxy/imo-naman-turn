using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{ 
    public GameObject target;
    void Update()
    {
        transform.up = target.transform.position;   
    }
}
