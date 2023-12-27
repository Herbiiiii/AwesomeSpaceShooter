using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    // Ссылка на префаб звезды
    public GameObject StarGO;
    // Максимальное количество звезд
    public int MaxStars;

    // Массив цветов для звезд
    Color[] starColors = {
        new Color(0.5f, 0.5f, 1f),
        new Color(0, 1f, 1f),
        new Color(1f, 1f, 0),
        new Color(1f, 0, 0),
    };

    // Start вызывается перед первым кадром
    void Start()
    {
        // Получаем границы экрана
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Создаем заданное количество звезд
        for (int i = 0; i < MaxStars; ++i)
        {
            // Создаем звезду из префаба
            GameObject star = (GameObject)Instantiate(StarGO);

            // Устанавливаем цвет звезды из массива цветов с учетом остатка от деления
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            // Размещаем звезду в случайной позиции на экране
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            // Устанавливаем случайную скорость звезды со знаком минус
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            // Устанавливаем звезду в качестве дочернего объекта текущего объекта StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update вызывается один раз за кадр
    void Update()
    {
        // Метод Update может быть использован для обновления состояния, но в данном случае он пустой
    }
}
