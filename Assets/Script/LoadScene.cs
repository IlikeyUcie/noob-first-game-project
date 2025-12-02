using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    private AsyncOperation operation;
    // Start is called before the first frame update
    void Start()
    {
        LoadSlider();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSlider()
    {
        StartCoroutine(Load());
    }
    public IEnumerator Load()
    {
        operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            int progress = (int)(operation.progress / 0.9f);
            slider.value = progress;
            text.text = progress * 100 + "%";
            yield return null;
        }
    }
}
