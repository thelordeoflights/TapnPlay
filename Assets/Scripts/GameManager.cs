using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject kiosk;
    [SerializeField] GameObject newArea;
    [SerializeField] Transform moneySpawn;
    [SerializeField] GameObject money;
    [SerializeField] CurrencyState currencyState;
    [SerializeField] ParticleSystem _particleSystem;

    [SerializeField] GameObject npcPrefab;

    [SerializeField] Transform npcSpawn;
    [SerializeField] Transform platformPosition;

    [SerializeField] private QueueState queueState;

    QueueHandler queueHandler;

    public AudioSource audioSource;


    public GameObject Buttons;
    public Button areaButton;
    public Button kioskButton;
    public float minWait;
    public float maxWait;



    private bool isSpawning;


    void Awake()
    {
        isSpawning = false;
        _particleSystem.Stop();
        audioSource.Stop();
        queueHandler = GetComponent<QueueHandler>();
    }

    void Update()
    {
        EnableButtons();
        // if (!isSpawning)
        // {
        //     float timer = Random.Range(minWait, maxWait);
        //     Invoke("SpawnObject", timer);
        //     isSpawning = true;
        // }

        if (queueState.availableSlots > 0)
        {
            SpawnNCP();
        }


    }

    void SpawnObject()
    {
        Instantiate(money, moneySpawn, true);
        // isSpawning = false;
    }
    void EnableButtons()
    {
        if (currencyState.currency >= 50)
        {
            kioskButton.interactable = true;
        }
        if (currencyState.currency >= 100)
        {
            areaButton.interactable = true;
        }
    }
    void Start()
    {
        kiosk.SetActive(false);
        newArea.SetActive(false);
        kioskButton.interactable = false;
        areaButton.interactable = false;
        Buttons.SetActive(false);
    }
    public void AreaButton()
    {
        newArea.SetActive(true);
        areaButton.gameObject.SetActive(false);
    }
    public void Kiosk()
    {
        kiosk.SetActive(true);
        kioskButton.gameObject.SetActive(false);

    }
    public void PlayParticle()
    {
        _particleSystem.Play();
    }

    public void MoneyCollected()
    {
        queueHandler.processNpcInFirst(platformPosition.position);
    }

    public void SpawnNCP()
    {
        var npcObject = Instantiate(npcPrefab, npcSpawn.position, npcSpawn.rotation);
        queueHandler.addNpcInQueue(npcObject);
        SpawnObject();
    }

}
