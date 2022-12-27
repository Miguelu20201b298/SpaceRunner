using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{inGame,menu,GameOver};
public class GameManager : MonoBehaviour
{
    public GameState gameState= GameState.menu;
    public static GameManager obj;
    private PlayerController jugador;
    public int collectableObj = 0;
    private void Awake()
    {
        if(obj==null)
        obj = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)&& gameState!=GameState.inGame)
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Menu();
        }
    }

    public void StartGame()
    {
        setGameState(GameState.inGame);
    }

    public void Menu()
    {
        setGameState(GameState.menu);
        AudioManager.obj.PlayMenu();
    }
    public void GameOver()
    {
        setGameState(GameState.GameOver);
    }

    private void setGameState(GameState newState)
    {
        if(newState==GameState.menu)
        {
            MenuManager.obj.MostrarMenu();
            MenuManager.obj.OcultarGameOver();
            MenuManager.obj.OcultarGameCanvas();
        }
        else if (newState == GameState.inGame)
        {
            MenuManager.obj.OcultarGameOver();
            MenuManager.obj.OcultarMenu();
            MenuManager.obj.MostrarGameCanvas();
            LevelManager.levelobj.RemoveAllLevels();
            LevelManager.levelobj.GenerateInitial();
            jugador.StartGame();
        }
        else if(newState == GameState.GameOver)
        {
            MenuManager.obj.OcultarGameCanvas();
            MenuManager.obj.MostrarGameOver();
        }
        gameState = newState;
    }

    public void CollectableOBJ(Collectable collectable)
    {
        collectableObj += collectable.value;
    }
    public void resetCoin()
    {
        collectableObj = 0;
    }
}
