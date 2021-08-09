using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    private CinemachineVirtualCamera virtualCamera;
    private int currentTargetIndex;

    private void Start() 
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();    
    }
    public void SelectTarget()
    {
        if(spawner.activeUnits.Count > 0)
        {
            if(currentTargetIndex >= spawner.activeUnits.Count)
                {
                    currentTargetIndex = 0;
                }
            virtualCamera.Follow = spawner.activeUnits[currentTargetIndex].transform;
            virtualCamera.LookAt = spawner.activeUnits[currentTargetIndex].transform;
        }

    }
    public void SelectNextTarget()
    {
        currentTargetIndex++;

        SelectTarget();
    }
}
