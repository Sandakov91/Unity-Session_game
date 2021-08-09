using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float unitSpeed;
    [SerializeField] private float unitRotationSpeed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private Gun unitGun;

    private Rigidbody unitRigidbody;
    private MeshRenderer unitMesh;
    private Unit currentEnemy;
    private bool canShoot;

    public UnitHP HP {get; private set;}
    public UnitStats Stats {get; private set;}
    public Spawner HostSpawner {get; private set;}
    public Spawner EnemySpawner {get; private set;}
    void Awake()
    {
        unitMesh = GetComponentInChildren<MeshRenderer>();
        unitRigidbody = GetComponent<Rigidbody>();
        HP = GetComponent<UnitHP>();
        Stats = GetComponent<UnitStats>();
    }
    private void Start() 
    {
        InvokeRepeating("SelectClosestEnemy", 0f, 0.5f);
    }
    private void FixedUpdate() 
    {
        ApplyMovement();
        ApplyShooting();
    }
    private void OnTriggerEnter(Collider other) 
    {
        Explosion explosion = other.GetComponent<Explosion>();
        if(explosion && explosion.HostUnit.HostSpawner != HostSpawner)
        {
            explosion.DealDamage(this);
        }
    }
    public void SetValues(Color _color, Spawner _hostSpawner, Spawner _enemySpawner)
    {
        unitMesh.material.color = _color;
        HostSpawner = _hostSpawner;
        EnemySpawner = _enemySpawner;
    }
    private void SelectClosestEnemy()
    {
        float distance = Mathf.Infinity;
        foreach (Unit enemy in EnemySpawner.activeUnits)
        {
            if((transform.position - enemy.transform.position).magnitude < distance)
            {
                currentEnemy = enemy;
                distance = (transform.position - enemy.transform.position).magnitude;
            }
        }
    }
    private void ApplyMovement()
    {
        if(currentEnemy)
        {
            Vector3 directionToEnemy = currentEnemy.transform.position - unitRigidbody.transform.position;
            Quaternion angleToEnemy = Quaternion.LookRotation(directionToEnemy);
            unitRigidbody.transform.rotation = Quaternion.Slerp(transform.rotation, angleToEnemy, unitRotationSpeed * Time.fixedDeltaTime);
            if(directionToEnemy.magnitude > stoppingDistance)
            {
                canShoot = false;
                unitRigidbody.velocity = unitRigidbody.transform.TransformDirection(Vector3.forward * unitSpeed * Time.fixedDeltaTime);
            }  
            else
            {
                canShoot = true;
            }
        }
    }
    private void ApplyShooting()
    {
        if(canShoot)
        {
            unitGun.Shoot();
        }
    }
}
