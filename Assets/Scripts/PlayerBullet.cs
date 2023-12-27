using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Скорость полета пули
    float speed;

    // Start вызывается перед первым кадром
    void Start()
    {
        // Устанавливаем начальную скорость пули
        speed = 8f;
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Получаем текущую позицию пули
        Vector2 position = transform.position;

        // Обновляем позицию для перемещения пули вверх на основе скорости и времени
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Устанавливаем новую позицию
        transform.position = position;

        // Получаем максимальную точку экрана
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Проверяем, вышла ли пуля за верхнюю границу экрана
        if (transform.position.y > max.y)
        {
            // Если да, уничтожаем объект пули
            Destroy(gameObject);
        }
    }

    // Метод, вызываемый при столкновении с другим коллайдером
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Проверяем тэг столкнувшегося объекта
        if (col.tag == "EnemyShipTag")
        {
            // Если это вражеский корабль, уничтожаем пулю
            Destroy(gameObject);
        }
    }
}
