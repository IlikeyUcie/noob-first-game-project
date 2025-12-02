using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject DialogBox;
    public string Text;
    public TMP_Text DialogText;
    private bool _inSign;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_inSign && GameManager.isInteract)
            OpenOrCloseDialog();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D )
            _inSign = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CapsuleCollider2D)
        {
            if (DialogBox != null)
                DialogBox.SetActive(false);
            _inSign = false;
        }
    }
    void OpenOrCloseDialog()
    {
        if (!DialogBox.activeSelf)
        {
            DialogBox.SetActive(true);
            DialogText.text = Text;
            GameManager.isInteract = false;
        }
        else
        {
            DialogBox.SetActive(false);
            GameManager.isInteract = false;
        }
    }
}
