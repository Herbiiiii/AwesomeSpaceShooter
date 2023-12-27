using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Префаб врага
    public GameObject EnemyGO;

    // Максимальная частота появления врагов в секундах
    float maxSpawnRateInSeconds = 5f;

    // Start вызывается перед первым кадром
    void Start()
    {
        // Пустой метод Start, так как в данном скрипте нет дополнительной инициализации
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Пустой метод Update, так как в данном скрипте нет дополнительной логики обновления
    }

    // Метод для создания врага
    void SpawnEnemy()
    {
        // Получение координат видимой области камеры (левый нижний угол и правый верхний угол)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Создание экземпляра врага и установка его позиции в случайное место в верхней части экрана
        GameObject anEnemy = Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        // Запланировать следующий спаун врага
        ScheduleNextEnemySpawn();
    }

    // Метод для планирования следующего спауна врага
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        // Выбор случайного времени до следующего спауна в пределах от 1 до максимальной частоты
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        // Запланировать вызов метода SpawnEnemy через выбранное время
        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    // Метод для увеличения частоты спауна врагов
    void IncreaseSpawnRate()
    {
        // Уменьшение максимальной частоты на 1 секунду
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }

        // Остановка увеличения частоты, если достигнут минимальный предел
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    // Метод для запуска спауна врагов
    public void ScheduleEnemySpawner()
    {
        // Установка начальной максимальной частоты и запуск спауна первого врага
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        // Запуск увеличения частоты спауна каждые 30 секунд
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Метод для отмены запланированных вызовов спауна врагов
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
