using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    private float bulletSpeed;
    private int bulletDamage;
    private Unit hostUnit;
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        bulletRigidbody.velocity = bulletRigidbody.transform.TransformDirection(Vector3.forward * bulletSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision other) 
    {
        Unit enemy = other.gameObject.GetComponent<Unit>();
        if(enemy && enemy.HostSpawner != hostUnit.HostSpawner)
        {
            if(enemy.HP.CurrentHP > bulletDamage)
            {
                enemy.HP.HitUnit(bulletDamage, hostUnit);
            }
            else
            {
                enemy.HP.KillUnit(hostUnit);
                Explosion explosion = ExplosionPool.Instance.GetFromPool(enemy.transform.position, enemy.transform.rotation);
                explosion.SetValues(hostUnit);
                explosion.PlayExplosionAnimation();
            }
        }
        BulletsPool.Instance.ReturnToPool(this);
    }
    public void SetValues(float _bulletSpeed, int _bulletDamage, Unit _hostUnit)
    {
        bulletSpeed = _bulletSpeed;
        bulletDamage = _bulletDamage;
        hostUnit = _hostUnit;
    }
}
