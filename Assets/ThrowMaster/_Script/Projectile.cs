using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    public float DamageMultiplier = 5.0f;
    private bool Hit = false;
    public AudioSource audioSource;

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
            
            // GameManager.Instance.Player2Health -= gameObject.GetComponent<Rigidbody>().velocity.magnitude*DamageMultiplier;
            GameManager.Instance.Player2Health -= 20.0f;
            GameManager.Instance.Player2Healthbar.fillAmount = GameManager.Instance.Player2Health/100.0f;
             audioSource.Play(0);

        } 
        }
        else if (GameManager.Instance.CurrentPlayer == Player.Player2Throw) 
        {
        if (other.gameObject.tag == "Player1" && !Hit)
        {
            Hit = true;
            GameManager.Instance.Player1Health -= 20.0f;
            // GameManager.Instance.Player1Health -= gameObject.GetComponent<Rigidbody>().velocity.magnitude*DamageMultiplier;
            GameManager.Instance.Player1Healthbar.fillAmount = GameManager.Instance.Player1Health/100.0f;
             audioSource.Play(0);

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
