using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float minHeight; // границы перемещение игрока
    [SerializeField] private float maxHeight;
    [SerializeField] private float moveIncrement; // величина перемещения игрока между границами

    [SerializeField] private float maxFuel = 100f; // максимум топлива
    [SerializeField] private float fuelConsumeRate = 0.5f; // потребление топлива со временем
    [SerializeField] private float fuelConsumeTime = 2.5f; // задержка между потреблениями топлива

    [SerializeField] private UIStatusBar fuelBar;
    [SerializeField] private ParticleSystem moveParticles;

    private float currentFuel; // текущее топливо
    private float fuelConsumeDelay; // счетчик задержки между потреблениями
    private PlayerHealth playerHealth;

    private void Awake()
    {
        currentFuel = maxFuel;
        fuelBar.SetMaxValue(maxFuel);
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Application.isMobilePlatform) MoveByTouch();
        else MoveByMouse();

        if (fuelConsumeDelay <= 0)
        {
            ChangeFuel(-fuelConsumeRate);
            fuelConsumeDelay = fuelConsumeTime;
        }
        else
        {
            fuelConsumeDelay -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Перемещение прикосновением к экрану смартфона
    /// </summary>
    private void MoveByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.y > Screen.height / 2 && transform.position.y < maxHeight)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + moveIncrement);
                }
                if (touch.position.y < Screen.height / 2 && transform.position.y > minHeight)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - moveIncrement);
                }
            }
        }
    }

    /// <summary>
    /// Перемещение кнопками мыши для тестирования
    /// </summary>
    private void MoveByMouse()
    {
        if (Input.GetMouseButtonDown(1) && transform.position.y > minHeight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveIncrement);
            Instantiate(moveParticles, transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(0) && transform.position.y < maxHeight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveIncrement);
            Instantiate(moveParticles, transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Регулирует текущее топливо на заданную величину
    /// </summary>
    public void ChangeFuel(float amount)
    {
        if (amount > 0)
        {
            currentFuel = Mathf.Clamp(currentFuel + amount, 0, maxFuel);
        }
        else 
        { 
            currentFuel += amount;
        }

        fuelBar.SetCurrentValue(currentFuel);

        if (currentFuel <= 0)
        {
            if (playerHealth.Health > 0)
            {
                currentFuel = maxFuel;
                playerHealth.ChangeHealth(-1);
            }
            else
            {
                playerHealth.Die();
            }
        }
    }

    /// <summary>
    /// Событие под конец анимации входа в телепорт
    /// </summary>
    public void EnterStargate()
    {
        Debug.Log("You escaped!");
        RestartMenu.GameWon();
        gameObject.SetActive(false);
    }
}
