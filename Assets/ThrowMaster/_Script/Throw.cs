using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject projectile;
    public GameObject weapon;
    public GameObject projectileSpawn;
    public LineRenderer trajectory;
    void SetTrajectory(bool active)
    {
        trajectory.enabled = active;
    }

    void ShowTrajectory()
    {
        SetTrajectory(true);
        int segmentCount = 25;
        Vector3[] segments = new Vector3[segmentCount];
        segments[0] = projectileSpawn.transform.position;

        Vector3 velocity = projectileSpawn.transform.up * force;

        for (int i = 0; i < segmentCount; i++)
        {
            float timeCurve = (i * Time.fixedDeltaTime);
            segments[i] = segments[0] + velocity * timeCurve + 0.5f * Physics.gravity * Mathf.Pow(timeCurve, 2);
        }
        trajectory.positionCount = segmentCount;

        for (int j = 0; j < segmentCount ; j++)
        {
            trajectory.SetPosition(j, segments[j]);
        }
    }
    public float force = 0f;
    private bool charging = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShowTrajectory();
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
            SetTrajectory(false);
            var throwProjectile = Instantiate(projectile, projectileSpawn.transform.position, weapon.transform.rotation);
            throwProjectile.GetComponent<Rigidbody>().velocity = projectileSpawn.transform.up * force;
            force = 0f;
            GameManager.Instance.SetGameState(GameState.Throw);
            if (GameManager.Instance.CurrentPlayer == Player.Player1)
            {
                GameManager.Instance.CurrentPlayer = Player.Player1Throw;
            }
            else if (GameManager.Instance.CurrentPlayer == Player.Player2)
            {
                GameManager.Instance.CurrentPlayer = Player.Player2Throw;
            }
        }
    }
}
