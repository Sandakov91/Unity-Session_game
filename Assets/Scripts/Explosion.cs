using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int explosionDamage;
    [SerializeField] private float lifeTime;
    private float lifeTimer;
    public Unit HostUnit {get; private set;}

    private void Update() 
    {
        if(lifeTimer <= 0)
        {
            ExplosionPool.Instance.ReturnToPool(this);
        }
        lifeTimer -= Time.deltaTime;
    }

    public void DealDamage(Unit enemy)
    {
        if(enemy.HP.CurrentHP > explosionDamage)
            {
                enemy.HP.HitUnit(explosionDamage, HostUnit);
            }
        else
            {
                enemy.HP.KillUnit(HostUnit);
            }
    }
    public void SetValues(Unit _hostUnit)
    {
        lifeTimer = lifeTime;
        HostUnit = _hostUnit;
    }
    public void PlayExplosionAnimation()
    {
        particles.Play();
    }
}
