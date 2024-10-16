using UnityEngine;
using TMPro; // Подключаем TextMeshPro

public class BonusBase : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private string bonusText = "+100";
    [SerializeField] private int bonusPoints = 100;
    [SerializeField] private Color backgroundColor = Color.yellow;
    [SerializeField] private Color textColor = Color.black;

    private TextMeshPro textMesh; // Изменяем на TextMeshPro
    private PlayerScore playerScore; // Для добавления очков

    private void Start()
    {
        // Устанавливаем фон и текст бонуса
        GetComponent<SpriteRenderer>().color = backgroundColor;

        // Находим объект TextMeshPro и задаем значения
        textMesh = GetComponentInChildren<TextMeshPro>();
        textMesh.text = bonusText;
        textMesh.color = textColor;

        // Находим систему подсчета очков
        playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        // Двигаем бонус вниз
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Если бонус уходит за нижнюю границу экрана, уничтожаем его
        if (transform.position.y < -6f) // Замените -6f на актуальную координату нижней границы
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Если бонус касается ракетки, активируем бонус
        if (other.CompareTag("Pallet"))
        {
            BonusActivate();
            Destroy(gameObject);
        }
    }

    // Метод активации бонуса (по умолчанию добавляет 100 очков)
    public virtual void BonusActivate()
    {
        playerScore.AddScore(bonusPoints); // Добавляем очки игроку
    }
}
