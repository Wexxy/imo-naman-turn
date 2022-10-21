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
        // Hit = true;
        if (GameManager.Instance.CurrentPlayer == Player.Player1Throw)
        {
           if (other.gameObject.tag == "Player2" && !Hit)
        {
            Hit = true;
            
            GameManager.Instance.Player2Health -= gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        } 
        }
        else if (GameManager.Instance.CurrentPlayer == Player.Player2Throw) 
        {
        if (other.gameObject.tag == "Player1" && !Hit)
        {
            Hit = true;
            GameManager.Instance.Player1Health -= gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        }
        }
        if (GameManager.Instance.Player1Health <= 0 || GameManager.Instance.Player2Health <= 0)
        {
            GameManager.Instance.SetGameState(GameState.End);
        }
    }
    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject, 5f);
        GameManager.Instance.SwitchPlayer();
    }
}
