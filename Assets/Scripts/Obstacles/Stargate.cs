﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stargate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Animator>().SetTrigger("isEnterSG");
            AudioManager.instance.PlaySoundClip("StargateEscape");
        }
    }
}
