using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItem : MonoBehaviour
{
    [SerializeField] private float fuelAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().ChangeFuel(fuelAmount);
            AudioManager.instance.PlaySoundClip("FuelPickup");
            Destroy(gameObject);
        }
    }
}
