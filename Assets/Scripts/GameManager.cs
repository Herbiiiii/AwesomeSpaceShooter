using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Ссылки на игровые объекты в сцене
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;

    // Перечисление возможных состояний игрового менеджера
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;

    // Start вызывается перед первым кадром
    void Start()
    {
        // Устанавливаем начальное состояние игрового менеджера
        GMState = GameManagerState.Opening;
    }

    // Метод для обновления состояния игрового менеджера
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            // Состояние открытия игры
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                GameTitleGO.SetActive(true);
                playButton.SetActive(true);
                break;

            // Состояние игрового процесса
            case GameManagerState.Gameplay:
                // Обнуляем счет
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                GameTitleGO.SetActive(false);

                // Инициализируем игрока и запускаем спаун врагов
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;

            // Состояние завершения игры
            case GameManagerState.GameOver:
                // Останавливаем отсчет времени и прекращаем спаун врагов
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                // Отображаем экран завершения игры и переходим к состоянию открытия после задержки
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }

    // Метод для установки состояния игрового менеджера
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    // Метод для начала игрового процесса
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    // Метод для перехода к состоянию открытия
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
