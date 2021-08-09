using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int SerialNumber {get; private set;}
    public int ID {get; private set;}
    public int DamageDealt {get; private set;}
    public int UnitsKilled {get; private set;}
    public int Experience {get; private set;}

    private void Start() 
    {
        ID = gameObject.GetInstanceID();
    }
    public void SetSerialNumber(int _serialNumber)
    {
        SerialNumber = _serialNumber;
    }
    public void SetValues(int _damageDealt, int _experience)
    {
        DamageDealt += _damageDealt;
        Experience += _experience;
    }
    public void SetValues(int _damageDealt, int _experience, int _unitsKilled)
    {
        DamageDealt += _damageDealt;
        Experience += _experience;
        UnitsKilled += _unitsKilled;
    }
}
