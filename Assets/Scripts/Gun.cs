using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Unit hostUnit;
    [SerializeField] private ParticleSystem shootingEffect;
    private bool canShoot;
    private float reloadTimer;

    private void Update() 
    {
        Reload();
    }
    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            reloadTimer = reloadTime;
            Bullet bullet = BulletsPool.Instance.GetFromPool(shootingPoint.position, shootingPoint.rotation);
            bullet.SetValues(bulletSpeed, bulletDamage, hostUnit);
            shootingEffect.Play();
        }
    }
    private void Reload()
    {
        if(reloadTimer <= 0f)
        {
            canShoot = true;
        }
        reloadTimer -= Time.deltaTime;
    }
}
