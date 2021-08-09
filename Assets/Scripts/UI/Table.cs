using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject winnerText;
    [SerializeField] private Row[] rows;

    public void SetRows()
    {
        List<Unit> units = spawner.allUnits;
        units = units.OrderByDescending(unit => unit.Stats.Experience).ToList();
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].SetRowValues(units[i].Stats.SerialNumber, units[i].Stats.ID, units[i].Stats.DamageDealt, units[i].Stats.UnitsKilled, units[i].Stats.Experience);
        }
    }
    public void ActivateWinnerText()
    {
        winnerText.SetActive(true);
    }
}
