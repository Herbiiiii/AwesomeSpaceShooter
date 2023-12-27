using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; // Массив объектов планет

    Queue<GameObject> availablePlanets = new Queue<GameObject>(); // Очередь доступных планет
    Vector2 min; // Минимальная точка экрана
    Vector2 max; // Максимальная точка экрана

    // Start вызывается перед первым кадром
    void Start()
    {
        // Заполняем очередь начальными планетами
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        // Определение минимальной и максимальной точек экрана
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Устанавливаем вызов метода MovePlanetDown с периодичностью каждые 20 секунд
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Метод Update может быть использован для обновления состояния, но в данном случае он пустой
    }

    // Метод для перемещения планет вниз
    void MovePlanetDown()
    {
        EnqueuePlanets(); // Добавляем планеты в очередь

        // Проверяем, есть ли доступные планеты
        if (availablePlanets.Count == 0)
            return;

        // Извлекаем планету из очереди
        GameObject aPlanet = availablePlanets.Dequeue();

        // Устанавливаем флаг движения для выбранной планеты
        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    // Метод для добавления планет в очередь
    void EnqueuePlanets()
    {
        // Перебираем все планеты в массиве
        foreach (GameObject aPlanet in Planets)
        {
            // Проверяем, находится ли планета ниже экрана и не движется ли она уже
            if ((aPlanet.transform.position.y < min.y) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                // Сбрасываем позицию планеты и добавляем ее в очередь
                aPlanet.GetComponent<Planet>().ResetPosition();
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
