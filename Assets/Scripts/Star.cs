using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Скорость движения звезды
    public float speed;

    // Метод Start вызывается перед первым кадром
    void Start()
    {
        // Код инициализации может быть размещен здесь, если необходимо
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Получаем текущую позицию звезды
        Vector2 position = transform.position;

        // Обновляем позицию для перемещения звезды вверх на основе скорости и времени
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Устанавливаем новую позицию
        transform.position = position;

        // Получаем минимальную и максимальную точки экрана
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Проверяем, вышла ли звезда за пределы нижней границы экрана
        if (transform.position.y < min.y)
        {
            // Если да, перемещаем звезду в случайную позицию над экраном
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
