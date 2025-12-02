using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public static  int _coinNumber;
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    private void Awake()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        coinText.text = _coinNumber.ToString();
    }
}
