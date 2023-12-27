using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; // ������ �������� ������

    Queue<GameObject> availablePlanets = new Queue<GameObject>(); // ������� ��������� ������
    Vector2 min; // ����������� ����� ������
    Vector2 max; // ������������ ����� ������

    // Start ���������� ����� ������ ������
    void Start()
    {
        // ��������� ������� ���������� ���������
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        // ����������� ����������� � ������������ ����� ������
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // ������������� ����� ������ MovePlanetDown � �������������� ������ 20 ������
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update ���������� ���� ��� �� ����
    void Update()
    {
        // ����� Update ����� ���� ����������� ��� ���������� ���������, �� � ������ ������ �� ������
    }

    // ����� ��� ����������� ������ ����
    void MovePlanetDown()
    {
        EnqueuePlanets(); // ��������� ������� � �������

        // ���������, ���� �� ��������� �������
        if (availablePlanets.Count == 0)
            return;

        // ��������� ������� �� �������
        GameObject aPlanet = availablePlanets.Dequeue();

        // ������������� ���� �������� ��� ��������� �������
        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    // ����� ��� ���������� ������ � �������
    void EnqueuePlanets()
    {
        // ���������� ��� ������� � �������
        foreach (GameObject aPlanet in Planets)
        {
            // ���������, ��������� �� ������� ���� ������ � �� �������� �� ��� ���
            if ((aPlanet.transform.position.y < min.y) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                // ���������� ������� ������� � ��������� �� � �������
                aPlanet.GetComponent<Planet>().ResetPosition();
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
