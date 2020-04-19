using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject menuHeader;
    [SerializeField] private Sprite loseHeader; // заголовок при поражении
    [SerializeField] private Sprite winHeader; // заголовок при победе

    /// <summary>
    /// Делегат для уведомления о поражении
    /// </summary>
    public static Action GameLost;
    /// <summary>
    /// Делегат для уведомления о победе
    /// </summary>
    public static Action GameWon;

    private void Awake()
    {
        GameLost = ShowLoseMenu;
        GameWon = ShowWinMenu;
    }

    /// <summary>
    /// Вызов меню поражения
    /// </summary>
    public void ShowLoseMenu()
    {
        menuHeader.GetComponent<Image>().sprite = loseHeader;
        PauseGame();
    }

    /// <summary>
    /// Вызов меню победы
    /// </summary>
    public void ShowWinMenu()
    {
        menuHeader.GetComponent<Image>().sprite = winHeader;
        PauseGame();
    }

    /// <summary>
    /// Пауза в игре
    /// </summary>
    public void PauseGame()
    {
        restartMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Снять паузу в игре
    /// </summary>
    public void ResumeGame()
    {
        restartMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Перезапустить уровень
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    /// <summary>
    /// Возврат в главное меню
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }
}
