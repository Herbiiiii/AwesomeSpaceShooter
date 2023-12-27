using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // Префаб пули врага
    public GameObject EnemyBulletGO;

    // Start вызывается перед первым кадром
    void Start()
    {
        // Запуск метода стрельбы вражеской пулей с задержкой в 1 секунду
        Invoke("FireEnemyBullet", 1f);
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Пустой метод Update, так как в данном скрипте нет дополнительной логики обновления
    }

    // Метод для стрельбы вражеской пулей
    void FireEnemyBullet()
    {
        // Поиск игрового объекта игрока по имени
        GameObject playerShip = GameObject.Find("PlayerGO");

        // Проверка, найден ли игровой объект игрока
        if (playerShip != null)
        {
            // Создание экземпляра вражеской пули
            GameObject bullet = Instantiate(EnemyBulletGO);

            // Установка позиции пули равной позиции орудия врага
            bullet.transform.position = transform.position;

            // Вычисление направления движения пули к игроку
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            // Установка направления движения вражеской пули
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
