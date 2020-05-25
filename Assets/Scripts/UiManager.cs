using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinCounterText;

    void Start()
    {
        _coinCounterText.text = "COINS " + 0;
    }
    
    public void UpdateCoinCount(int coinCount)
    {
        _coinCounterText.text = "COINS " + coinCount.ToString();
    }
}
