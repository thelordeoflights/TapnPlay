using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject Kiosk;
    [SerializeField] GameObject NewArea;
    [SerializeField] Transform moneySpawn;
    [SerializeField] GameObject money;
    public GameObject araButton;
    public GameObject kioskButton;
    public float minWait;
    public float maxWait;

    private bool isSpawning;


    void Awake()
    {
        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObject", timer);
            isSpawning = true;
        }
    }

    void SpawnObject()
    {
        Instantiate(money, moneySpawn, true);
        isSpawning = false;
    }
}
