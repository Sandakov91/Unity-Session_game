using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private float timeToRegenerate;
    private Unit hostUnit;
    private float regenerationTimer;
    public int CurrentHP {get; private set;}

    private void Awake() 
    {
        hostUnit = GetComponent<Unit>();
        regenerationTimer = timeToRegenerate;
        CurrentHP = maxHP;
    }
    private void Update() 
    {
        if(CurrentHP < maxHP)
        {
            Regenerate();
        }
    }

    public void HitUnit(int damage, Unit damager)
    {
        CurrentHP -= damage;
        damager.Stats.SetValues(damage, damage);
    }
    public void KillUnit(Unit damager)
    {
        damager.Stats.SetValues(CurrentHP, CurrentHP + maxHP, 1);
        hostUnit.HostSpawner.RemoveFromActiveUnits(hostUnit);
        UnitsPool.Instance.ReturnToPool(hostUnit);
        if(hostUnit.HostSpawner.HasCameraController)
        {
            hostUnit.HostSpawner.SetNewCameraTarget();
        }
    }
    private void Regenerate()
    {
        if(regenerationTimer <= 0)
        {
            regenerationTimer = timeToRegenerate;
            CurrentHP++;
        }
        regenerationTimer -= Time.deltaTime;
    }
}
