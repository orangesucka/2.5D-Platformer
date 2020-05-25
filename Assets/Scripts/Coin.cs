using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //private UiManager _uIManager;
    private int _coins;

    private void Start()
    {
        /*_uIManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        if (_uIManager == null)
        {
            Debug.Log("The UI Manager in Coin is NULL");
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.coinCounter();
                Debug.Log("Coin collected " + player._coins);
            }
            Destroy(this.gameObject);
        }
    }
    //Notify Ui from here or from the player
}
