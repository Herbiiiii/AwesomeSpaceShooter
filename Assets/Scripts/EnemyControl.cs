using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Ссылка на объект текста счёта
    GameObject scoreUITextGO;

    // Префаб взрыва
    public GameObject ExplosionGO;

    // Скорость движения врага
    float speed;

    // Start вызывается перед первым кадром
    void Start()
    {
        // Инициализация скорости
        speed = 2f;

        // Поиск объекта текста счёта по тегу
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Получение текущей позиции врага
        Vector2 position = transform.position;

        // Обновление позиции врага с учётом скорости
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        // Установка новой позиции врага
        transform.position = position;

        // Определение минимальной точки экрана в мировых координатах
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Проверка, выходит ли враг за границы экрана по вертикали
        if (transform.position.y < min.y)
        {
            // Уничтожение врага, если он выходит за границы экрана
            Destroy(gameObject);
        }
    }

    // Обработка столкновения с другими коллайдерами
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Проверка столкновения с врагом или пулей игрока
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            // Воспроизведение анимации взрыва
            PlayExplosion();

            // Увеличение счёта
            scoreUITextGO.GetComponent<GameScore>().Score += 100;

            // Уничтожение врага
            Destroy(gameObject);
        }
    }

    // Воспроизведение анимации взрыва
    void PlayExplosion()
    {
        // Создание экземпляра взрыва и установка его позиции
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
