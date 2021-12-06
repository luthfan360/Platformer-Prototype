using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text coinText;
    [SerializeField]
    Text livesText;
    
    public void UpdateCoins(int coins)
    {
        coinText.text = "COINS : " + coins;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "LIVES : " + lives;
    }
}
