using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject endTable;
    [SerializeField] private Table redTable;
    [SerializeField] private Table blueTable;
    [SerializeField] private Spawner redSpawner;
    [SerializeField] private Spawner blueSpawner;
    [SerializeField] private Timer timer;
    [SerializeField] private Button nextTargetButton;

    public bool IsGameStarted {get; private set;}

    public void StartGame()
    {
        redSpawner.SpawnUnits();
        blueSpawner.SpawnUnits();
        IsGameStarted = true;
    }
    public void EndGame()
    {
        IsGameStarted = false;
        Time.timeScale = 0f;
        timer.gameObject.SetActive(false);
        nextTargetButton.gameObject.SetActive(false);
        endTable.SetActive(true);
        if(redSpawner.isWinner)
        {
            redTable.ActivateWinnerText();
        }
        else if(blueSpawner.isWinner)
        {
            blueTable.ActivateWinnerText();
        }
        redTable.SetRows();
        blueTable.SetRows();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SelectWinner()
    {
        if(redSpawner.TotalScore() < blueSpawner.TotalScore())
        {
            blueSpawner.SetWinner();
        }
        else if(redSpawner.TotalScore() > blueSpawner.TotalScore())
        {
            redSpawner.SetWinner();
        }
    }
}
