using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI serialNumber;
    [SerializeField] private TextMeshProUGUI id;
    [SerializeField] private TextMeshProUGUI damageDealt;
    [SerializeField] private TextMeshProUGUI unitsKilled;
    [SerializeField] private TextMeshProUGUI experience;

    public void SetRowValues(int _serialNumber, int _id, int _damageDealt, int _unitsKilled, int _experience)
    {
        serialNumber.text = _serialNumber.ToString();
        id.text = _id.ToString();
        damageDealt.text = _damageDealt.ToString();
        unitsKilled.text = _unitsKilled.ToString();
        experience.text = _experience.ToString();
    }
}
