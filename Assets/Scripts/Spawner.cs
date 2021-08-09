using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawner enemySpawner;
    [SerializeField] private Color teamColor;
    [SerializeField] private int unitAmount;
    [SerializeField] private float bordersX;
    [SerializeField] private float bordersZ;
    [SerializeField] private CameraController cameraController;

    private MainMenu mainMenu;

    public bool HasCameraController => cameraController != null;
    public List<Unit> activeUnits {get; private set;}
    public List<Unit> allUnits {get; private set;}
    public bool isWinner {get; private set;}

    private void Start() 
    {
        cameraController = FindObjectOfType<CameraController>();
        mainMenu = FindObjectOfType<MainMenu>();
        activeUnits = new List<Unit>();
        allUnits = new List<Unit>();
    }
    private void Update() 
    {
        if(activeUnits.Count == 0 && mainMenu.IsGameStarted)
        {
            enemySpawner.SetWinner();
            mainMenu.EndGame();
        }
    }
    public void SpawnUnits()
    {
        for(int i = 0; i < unitAmount; i++)
        {
            Unit unit = UnitsPool.Instance.GetFromPool(new Vector3(Random.Range(this.transform.position.x - bordersX, this.transform.position.x + bordersX), 0f, Random.Range(this.transform.position.z - bordersZ, this.transform.position.z + bordersZ)), this.transform.rotation);
            unit.Stats.SetSerialNumber(i+1);
            activeUnits.Add(unit);
            allUnits.Add(unit);
            unit.SetValues(teamColor, this, enemySpawner);
            cameraController.SelectTarget();
        }
    }
    public void RemoveFromActiveUnits(Unit unit)
    {
        activeUnits.Remove(unit);
    }
    public int TotalScore()
    {
        int result = 0;
        foreach (Unit unit in allUnits)
        {
            result += unit.Stats.Experience;
        }
        return result;
    }
    public void SetWinner()
    {
        isWinner = true;
    }
    public void SetNewCameraTarget()
    {
        cameraController.SelectTarget();
    }
}
