using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed; // Скорость движения планеты
    public bool isMoving; // Флаг, указывающий, двигается ли планета

    Vector2 min; // Минимальная точка экрана
    Vector2 max; // Максимальная точка экрана

    // Awake вызывается при активации объекта
    void Awake()
    {
        // Инициализация флага движения и определение границ экрана
        isMoving = false;

        // Определение минимальной и максимальной точек экрана
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Коррекция максимальной точки по оси y для учета размера спрайта планеты
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        // Коррекция минимальной точки по оси y для учета размера спрайта планеты
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Если планета не двигается, прекращаем выполнение метода
        if (!isMoving)
            return;

        // Получаем текущую позицию планеты
        Vector2 position = transform.position;

        // Обновляем позицию для перемещения планеты вниз на основе скорости и времени
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Устанавливаем новую позицию
        transform.position = position;

        // Если планета выходит за нижнюю границу экрана, прекращаем ее движение
        if (transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    // Метод для сброса позиции планеты в случайную точку над экраном
    public void ResetPosition()
    {
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
