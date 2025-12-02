using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    private Image _screenFlash;
    public float time;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        _screenFlash = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Flash()
    {
        StartCoroutine(FlashTIme());
    }
     IEnumerator FlashTIme()
    {
        _screenFlash.enabled = true;
        yield return new WaitForSeconds(time);
        _screenFlash.enabled = false;
        
    }
}
