using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject lastButton;
    // Start is called before the first frame update
    private void Awake()
    {
        lastButton = new GameObject();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastButton);
        }
        else
        {
            lastButton = EventSystem.current.currentSelectedGameObject;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
