using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimingManager timingManager;

    private void Start()
    {
        timingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        // 판정 체크
        if (Input.GetKeyDown(KeyCode.S))
            timingManager.CheckTiming(0);
        if (Input.GetKeyDown(KeyCode.D))
            timingManager.CheckTiming(1);
        if (Input.GetKeyDown(KeyCode.F))
            timingManager.CheckTiming(2);
        if (Input.GetKeyDown(KeyCode.J))
            timingManager.CheckTiming(3);
        if (Input.GetKeyDown(KeyCode.K))
            timingManager.CheckTiming(4);
        if (Input.GetKeyDown(KeyCode.L))
            timingManager.CheckTiming(5);
    }
}
