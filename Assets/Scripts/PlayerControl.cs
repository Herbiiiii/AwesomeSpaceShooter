using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    // Ссылка на объект GameManager
    public GameObject GameManagerGO;

    // Ссылки на различные объекты, используемые игроком
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;
    public GameObject ExplosionGO;

    // Ссылка на текстовое поле UI для отображения оставшихся жизней
    public TextMeshProUGUI LivesUIText;

    // Константа для максимального количества жизней игрока
    const int MaxLives = 3;
    int lives;

    // Скорость движения игрока
    public float speed;

    // Инициализация состояния игрока
    public void Init()
    {
        lives = MaxLives;

        // Обновление текста UI с начальным количеством жизней
        LivesUIText.text = lives.ToString();

        // Установка начальной позиции игрока
        transform.position = new Vector2(0, 0);

        // Активация объекта игрока
        gameObject.SetActive(true);
    }

    // Метод, вызываемый при старте
    void Start()
    {
        // Код инициализации может быть размещен здесь, если необходимо
    }

    // Метод, вызываемый каждый кадр
    void Update()
    {
        // Проверка нажатия клавиши "пробел" для стрельбы пулями
        if (Input.GetKeyDown("space"))
        {
            // Воспроизведение звука выстрела
            GetComponent<AudioSource>().Play();

            // Создание пуль на указанных позициях
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = BulletPosition02.transform.position;
        }

        // Получение ввода для движения игрока
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        // Движение игрока на основе ввода
        Move(direction);
    }

    // Движение игрока в пределах границ экрана
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Корректировка значений min и max, чтобы предотвратить выход игрока за границы экрана
        max.x = max.x - 0.225f;
        min.x = min.x + 0.255f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        // Обновление позиции игрока на основе ввода, скорости и времени
        pos += direction * speed * Time.deltaTime;

        // Ограничение позиции игрока, чтобы оставаться в пределах границ экрана
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    // Обработка столкновений с другими объектами
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            // Запуск взрыва и уменьшение количества жизней при столкновении с врагом
            PlayExplosion();
            lives--;
            LivesUIText.text = lives.ToString();

            if (lives == 0)
            {
                // Если жизней не осталось, установка состояния "конец игры" и деактивация игрока
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    // Создание и установка позиции объекта взрыва
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
