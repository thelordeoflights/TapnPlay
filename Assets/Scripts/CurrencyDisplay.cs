using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] CurrencyState currencyState;


    // Update is called once per frame
    void Update()
    {
        string[] temp = textMeshProUGUI.text.Split('₹');
        textMeshProUGUI.text = temp[0] + "₹" + currencyState.currency;
    }
}
