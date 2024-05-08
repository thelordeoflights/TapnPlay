using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{

    public int value = 0;
    GameManager gameManager;
    [SerializeField] CurrencyState currencyState;
    void Start()
    {

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform == transform)
                {
                    processCurrency();

                }
            }
        }

    }

    private void processCurrency()
    {
        currencyState.currency += value;
        gameManager.PlayParticle();
        gameManager.audioSource.Play();
        gameManager.MoneyCollected();
        Destroy(gameObject);
    }
}
