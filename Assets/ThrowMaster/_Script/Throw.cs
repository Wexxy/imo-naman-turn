using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject projectile;
    public GameObject weapon;
    public GameObject projectileSpawn;
    

    public float force = 0f;
    private bool charging = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (charging)
            {
                force += .2f;
            }
            else
            {
                force -= .2f;
            }
            if (force >= 20)
            {
                charging = false;
            }
            else if (force <= 0)
            {
                charging = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            var throwProjectile = Instantiate(projectile, projectileSpawn.transform.position, weapon.transform.rotation);
            throwProjectile.GetComponent<Rigidbody>().velocity = projectileSpawn.transform.up * force;
            force = 0f;
        }
    }
}
