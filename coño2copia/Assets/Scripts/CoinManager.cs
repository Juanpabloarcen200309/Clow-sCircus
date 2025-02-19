using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TMP_Text coinText;
    public int coinCount = 0;
    public int coinsToActivate = 2; // Límite de monedas en 2
    public GameObject objectToActivate; // Objeto a activar al recolectar 2 monedas

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        if (coinCount < 2) // Evita que pase de 2
        {
            coinCount++;
            UpdateCoinText();
            CheckCoins();
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "Llaves: " + coinCount;
    }

    private void CheckCoins()
    {
        if (coinCount >= coinsToActivate)
        {
            objectToActivate.SetActive(true);
        }
    }
}
