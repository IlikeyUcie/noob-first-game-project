using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBack : MonoBehaviour
{
    public GameObject selda1;
    public GameObject selda2;
    private Animator changeBack;
    // Start is called before the first frame update
    private void Awake()
    {
        changeBack = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            changeBack.SetBool("Change",true);

        }
        
    }
    public void Change()
    {
        selda1.SetActive(false);
        selda2.SetActive(true);
        
    }
}
