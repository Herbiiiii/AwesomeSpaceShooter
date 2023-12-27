using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // ������ ���� �����
    public GameObject EnemyBulletGO;

    // Start ���������� ����� ������ ������
    void Start()
    {
        // ������ ������ �������� ��������� ����� � ��������� � 1 �������
        Invoke("FireEnemyBullet", 1f);
    }

    // Update ���������� ���� ��� �� ����
    void Update()
    {
        // ������ ����� Update, ��� ��� � ������ ������� ��� �������������� ������ ����������
    }

    // ����� ��� �������� ��������� �����
    void FireEnemyBullet()
    {
        // ����� �������� ������� ������ �� �����
        GameObject playerShip = GameObject.Find("PlayerGO");

        // ��������, ������ �� ������� ������ ������
        if (playerShip != null)
        {
            // �������� ���������� ��������� ����
            GameObject bullet = Instantiate(EnemyBulletGO);

            // ��������� ������� ���� ������ ������� ������ �����
            bullet.transform.position = transform.position;

            // ���������� ����������� �������� ���� � ������
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            // ��������� ����������� �������� ��������� ����
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
