using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        coins = 0;
        coinText.text = $"Coin: {coins.ToString()}";
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = $"Coin: {coins.ToString()}";
    }

}
