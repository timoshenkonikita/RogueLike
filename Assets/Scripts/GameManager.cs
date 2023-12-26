using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //������ ��������� ����
   public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    //������� ���������
    public GameState currentState;
    //���������� ���������
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
                Debug.LogWarning("��������� �� ����������");
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
            Time.timeScale = 0f; //��������� ����
            pauseScreen.SetActive(true);
            Debug.Log("�����");
        }
        
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f; //������������� ����
            pauseScreen.SetActive(false);
            Debug.Log("���� ������������");
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
