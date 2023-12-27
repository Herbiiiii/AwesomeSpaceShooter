using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Добавленная директива

public class TimeCounter : MonoBehaviour
{
    TextMeshProUGUI timeUI; // Текстовое поле для отображения времени

    float startTime; // Время начала отсчета
    float ellapsedTime; // Прошедшее время
    bool startCounter; // Флаг, указывающий, идет ли отсчет времени

    int minutes; // Количество минут
    int seconds; // Количество секунд

    // Start вызывается перед первым кадром
    void Start()
    {
        startCounter = false;

        // Получаем компонент TextMeshProUGUI у текущего объекта
        timeUI = GetComponent<TextMeshProUGUI>();
    }

    // Метод для начала отсчета времени
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    // Метод для остановки отсчета времени
    public void StopTimeCounter()
    {
        startCounter = false;
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Проверяем, идет ли отсчет времени
        if (startCounter)
        {
            // Вычисляем прошедшее время
            ellapsedTime = Time.time - startTime;

            // Рассчитываем минуты и секунды
            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            // Форматируем строку времени и устанавливаем ее в текстовое поле
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
