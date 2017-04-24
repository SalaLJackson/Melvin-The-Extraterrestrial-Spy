using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    private Text coinTxt;

    private int collectedCoins;

    public static GameManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }

        set
        {
            instance = value;
        }


    }

    public GameObject CoinPrefab
    {
        get
        {
            return coinPrefab;
        }
    }

    public Text CoinTxt
    {
        get
        {
            return coinTxt;
        }

        set
        {
            coinTxt = value;
        }
    }

    public int CollectedCoins
    {
        get
        {
            return collectedCoins;
        }

        set
        {
            collectedCoins = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
