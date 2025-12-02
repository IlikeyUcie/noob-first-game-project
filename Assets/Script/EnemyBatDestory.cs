using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatDestory : MonoBehaviour
{
    public int batNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
       EasterEgg.password += batNumber.ToString();
    }
}
