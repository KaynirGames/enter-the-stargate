using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
    [SerializeField] private int healthAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().ChangeHealth(healthAmount);
            AudioManager.instance.PlaySoundClip("HealthPickup");
            Destroy(gameObject);
        }
    }
}
