using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool Hit = false;
    private void Awake()
    {
        StartCoroutine(ChangeState());
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player1" && !Hit)
        {
            Hit = true;
            GameManager.Instance.Player1Health -= 20;
        }
        else if (other.gameObject.tag == "Player2" && !Hit)
        {
            Hit = true;
            GameManager.Instance.Player2Health -= 20;
        }
    }
    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject, 5f);
        GameManager.Instance.SwitchPlayer();
    }
}
