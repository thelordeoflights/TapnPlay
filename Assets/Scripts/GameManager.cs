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
    [SerializeField] ParticleSystem ps;
    public GameObject Buttons;
    public Button areaButton;
    public Button kioskButton;
    public float minWait;
    public float maxWait;

    GameObject _money;


    private bool isSpawning;


    void Awake()
    {
        isSpawning = false;
    }

    void Update()
    {
        _money = GameObject.FindWithTag("Money").GetComponent<GameObject>();
        EnableButtons();
        if (!isSpawning)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObject", timer);
            isSpawning = true;
        }
        PlayEffects();
    }

    void SpawnObject()
    {
        Instantiate(money, moneySpawn, true);
        isSpawning = false;
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
    void PlayEffects()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform == _money)
                {
                    ps.Play();
                }
            }
        }
    }
}
