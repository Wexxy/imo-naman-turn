using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public enum GameState { Player1Turn,Player2Turn, Throw, End };

public enum Player { Player1, Player2, Player1Throw, Player2Throw };
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public Player CurrentPlayer;
    public GameObject Player1Camera;
    public GameObject Player2Camera;
    public GameObject ProjectileCamera;
    public float timer = 5f;

    public float turnStart;
    public GameObject Player1;
    public GameObject Player2;

    public float Player1Health = 100;
    public Image Player1Healthbar;
    public float Player2Health = 100;
    public Image Player2Healthbar;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        SetGameState(GameState.Throw);
        yield return new WaitForSeconds(5);
        SetGameState(GameState.Player1Turn);
    }

    public void SwitchPlayer()
    {
        if (CurrentPlayer == Player.Player1Throw)
        {
            SetGameState(GameState.Player2Turn);
        }
        else if (CurrentPlayer == Player.Player2Throw)
        {
            SetGameState(GameState.Player1Turn);
        }
        turnStart = Time.time;
    }

    public void SetGameState(GameState state)
    {
        State = state;

        switch (state)
        {
            case GameState.Player1Turn:
                CurrentPlayer = Player.Player1;
                Player1.GetComponent<Throw>().enabled = true;
                Player2.GetComponent<Throw>().enabled = false;
                Player1.GetComponent<RigBuilder>().enabled = true;
                Player2.GetComponent<RigBuilder>().enabled = false;
                Player1Camera.SetActive(true);
                Player2Camera.SetActive(false);
                ProjectileCamera.SetActive(false);
                break;
            case GameState.Throw:
                Player1.GetComponent<Throw>().enabled = false;
                Player2.GetComponent<Throw>().enabled = false;
                Player1.GetComponent<RigBuilder>().enabled = false;
                Player2.GetComponent<RigBuilder>().enabled = false;
                Player1Camera.SetActive(false);
                Player2Camera.SetActive(false);
                ProjectileCamera.SetActive(true);
                break;
            case GameState.Player2Turn:
                CurrentPlayer = Player.Player2;
                Player1.GetComponent<RigBuilder>().enabled = false;
                Player2.GetComponent<RigBuilder>().enabled = true;
                Player2.GetComponent<Throw>().enabled = true;
                Player1.GetComponent<Throw>().enabled = false;
                Player1Camera.SetActive(false);
                Player2Camera.SetActive(true);
                ProjectileCamera.SetActive(false);
                break;
            case GameState.End:
                CurrentPlayer = Player.Player1Throw;
                Player1.GetComponent<Throw>().enabled = false;
                Player2.GetComponent<Throw>().enabled = false;
                Player1.GetComponent<RigBuilder>().enabled = false;
                Player2.GetComponent<RigBuilder>().enabled = false;
                Player1Camera.SetActive(false);
                Player2Camera.SetActive(false);
                ProjectileCamera.SetActive(true);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
