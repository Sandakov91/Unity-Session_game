using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeToStart;
    [SerializeField] private float timeToEndRound;

    private TextMeshProUGUI timerTextMesh;
    private MainMenu mainMenu;
    private float timer;

    private void Start() 
    {
        timerTextMesh = GetComponent<TextMeshProUGUI>();
        mainMenu = FindObjectOfType<MainMenu>();
        timer = timeToStart;
    }
    private void Update() 
    {
        timerTextMesh.text = ((int)timer).ToString();
        if(timer <= 0 && !mainMenu.IsGameStarted)
        {
            timer = timeToEndRound;
            mainMenu.StartGame();
        }
        else if(timer <= 0 && mainMenu.IsGameStarted)
        {
            mainMenu.SelectWinner();
            mainMenu.EndGame();
        }
        timer -= Time.deltaTime;
    }
}
