using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ������ �����
    public GameObject EnemyGO;

    // ������������ ������� ��������� ������ � ��������
    float maxSpawnRateInSeconds = 5f;

    // Start ���������� ����� ������ ������
    void Start()
    {
        // ������ ����� Start, ��� ��� � ������ ������� ��� �������������� �������������
    }

    // Update ���������� ���� ��� �� ����
    void Update()
    {
        // ������ ����� Update, ��� ��� � ������ ������� ��� �������������� ������ ����������
    }

    // ����� ��� �������� �����
    void SpawnEnemy()
    {
        // ��������� ��������� ������� ������� ������ (����� ������ ���� � ������ ������� ����)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // �������� ���������� ����� � ��������� ��� ������� � ��������� ����� � ������� ����� ������
        GameObject anEnemy = Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        // ������������� ��������� ����� �����
        ScheduleNextEnemySpawn();
    }

    // ����� ��� ������������ ���������� ������ �����
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        // ����� ���������� ������� �� ���������� ������ � �������� �� 1 �� ������������ �������
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        // ������������� ����� ������ SpawnEnemy ����� ��������� �����
        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    // ����� ��� ���������� ������� ������ ������
    void IncreaseSpawnRate()
    {
        // ���������� ������������ ������� �� 1 �������
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }

        // ��������� ���������� �������, ���� ��������� ����������� ������
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    // ����� ��� ������� ������ ������
    public void ScheduleEnemySpawner()
    {
        // ��������� ��������� ������������ ������� � ������ ������ ������� �����
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        // ������ ���������� ������� ������ ������ 30 ������
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // ����� ��� ������ ��������������� ������� ������ ������
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
