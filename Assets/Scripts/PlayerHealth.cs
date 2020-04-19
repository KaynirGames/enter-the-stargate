using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Text healthDisplay;

    public int Health => health;

    /// <summary>
    /// Регулирует здоровье на заданную величину
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            GetComponent<Animator>().SetTrigger("TakeDamage");
            AudioManager.instance.PlaySoundClip("Impact");
        }

        health += amount;

        if (health < 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            health = 0;
        }

        healthDisplay.text = health.ToString();
    }

    /// <summary>
    /// Вызов меню поражения, событие под конец анимации гибели персонажа
    /// </summary>
    public void Die()
    {
        gameObject.SetActive(false);
        RestartMenu.GameLost();
    }

    /// <summary>
    /// Эффект взрыва, событие под конец анимации гибели персонажа
    /// </summary>
    public void ExplosionOnDeath()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySoundClip("Explosion");
    }
}
