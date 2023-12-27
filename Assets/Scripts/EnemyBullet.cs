using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Скорость снаряда
    float speed;

    // Направление движения снаряда
    Vector2 _direction;

    // Флаг, указывающий, готов ли снаряд двигаться
    bool isReady;

    // Awake вызывается при загрузке экземпляра скрипта
    void Awake()
    {
        // Инициализация скорости и установка флага в false
        speed = 5f;
        isReady = false;
    }

    // Start вызывается перед первым кадром
    void Start()
    {
        // Дополнительная инициализация, если необходимо
    }

    // Устанавливает начальное направление движения снаряда
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Проверка готовности снаряда двигаться
        if (isReady)
        {
            // Движение снаряда в указанном направлении
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            // Проверка, выходит ли снаряд за границы экрана
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                // Уничтожение снаряда, если он выходит за границы экрана
                Destroy(gameObject);
            }
        }
    }

    // Обработка столкновения с другими коллайдерами
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Проверка столкновения снаряда с кораблем игрока
        if (col.tag == "PlayerShipTag")
        {
            // Уничтожение снаряда при столкновении с кораблем игрока
            Destroy(gameObject);
        }
    }
}