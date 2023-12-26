using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //список состояний игры
   public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    //текущее состояние
    public GameState currentState;
    //предыдущее состояние
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;


    void Awake()
    {
        DisableScreens();   
    }
    void Update()
    {
        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                break;

            default:
                Debug.LogWarning("СОСТОЯНИЯ НЕ СУЩЕСТВУЕТ");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }
    public void PauseGame()
    {
        if(currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f; //остановка игры
            pauseScreen.SetActive(true);
            Debug.Log("Пауза");
        }
        
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f; //возобновление игры
            pauseScreen.SetActive(false);
            Debug.Log("Игра возобновлена");
        }
    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
    }
}
