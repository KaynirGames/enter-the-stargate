using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargateCharger : MonoBehaviour
{
    [SerializeField] private UIStatusBar stargateBar;
    [SerializeField] private int stargateMaxCharge; // максимальный заряд телепорта
    [SerializeField] private GameObject stargate;
    [SerializeField] private Transform stargatePoint; // точка спавна телепорта

    private int stargateCharge; // текущий заряд телепорта

    private void Awake()
    {
        stargateBar.SetMaxValue(stargateMaxCharge);
        stargateBar.SetCurrentValue(0);
        stargateCharge = 0;
    }

    private void Update()
    {
        if (stargateCharge == stargateMaxCharge)
        {
            Instantiate(stargate, stargatePoint.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            stargateCharge = Mathf.Clamp(stargateCharge + 1, 0, stargateMaxCharge);
            stargateBar.SetCurrentValue(stargateCharge);
        }
    }
}
