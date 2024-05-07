using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static string currencyName;
    public static int _currency = 0;
    [SerializeField] CurrencyState currencyState;
    void Start()
    {
        currencyState.currency = 0;
        _currency = PlayerPrefs.GetInt("currencyName");
    }
    public static void UpdateCurrency()
    {
        PlayerPrefs.SetInt("currencyName", _currency);
        _currency = PlayerPrefs.GetInt("currencyName");
        PlayerPrefs.Save();
    }
}
