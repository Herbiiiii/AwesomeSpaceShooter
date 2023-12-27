using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Метод для уничтожения текущего игрового объекта
    private void DestroyGameObject()
    {
        // Используем функцию Destroy из библиотеки Unity для удаления текущего объекта
        Destroy(gameObject);
    }

    // Метод Start вызывается перед первым кадром обновления
    void Start()
    {
        
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        
    }
}