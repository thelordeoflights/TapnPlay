using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDissableButton : MonoBehaviour
{
    [SerializeField] Button kisokButton;
    [SerializeField] Button areaButton;
    [SerializeField] CurrencyState currencyState;

    // Start is called before the first frame update
    void Start()
    {
        kisokButton.enabled = false;
        areaButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyState.currency >= 50)
        {
            kisokButton.enabled = true;
        }
        if (currencyState.currency >= 200)
        {
            areaButton.enabled = true;
        }
    }
}
