using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI; // Текстовое поле для отображения счета

    int score; // Переменная для хранения счета игры

    // Свойство для управления счетом с автоматическим обновлением текстового поля
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Start вызывается перед первым кадром
    void Start()
    {
        // Получаем компонент TextMeshProUGUI у текущего объекта
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    // Метод для обновления текстового поля счета
    void UpdateScoreTextUI()
    {
        // Форматируем счет в строку с нулями впереди и устанавливаем ее в текстовое поле
        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }
}
