using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSound : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        //Col·lisio amb les coins i so
        if (other.gameObject.tag == "Player")
        {
            AudioSource Coin = GetComponent<AudioSource>();
            Coin.Play();

            GameManager.Instance.CollectedCoins++;

            Destroy(gameObject);
        }
    }
}
