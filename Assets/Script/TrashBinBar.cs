using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashBinBar : MonoBehaviour
{
    public Image coinBar;
    public TMP_Text coinQuantity;
    public int maxCoinQuantity;
    private int _currentCoinQuantity;
    public RectTransform canvasPos; // 是指父对象的rectTransform组件，应该和Canvas的一样。
    public Transform trashBinPos;
    private RectTransform _trashBinBarPosition;
    public float yOffset;

    private void Awake()
    {
        _trashBinBarPosition = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasPos = transform.parent.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinText._coinNumber > 0)
            BarCreating();
        setTrashBinPosition();
    }
    void BarCreating()
    {
        if (GameManager.isInteract && TrashBin.inTrashBin)
        {
            if (_currentCoinQuantity < maxCoinQuantity)
            {
                CoinText._coinNumber--;
                _currentCoinQuantity++;
                coinBar.fillAmount = (float)_currentCoinQuantity / maxCoinQuantity;
                coinQuantity.text = _currentCoinQuantity + "/" + maxCoinQuantity;
                AudioManager.ThrowCoin();
            }
            else
                return;
        }
    }
    void setTrashBinPosition()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(trashBinPos.position);
        Vector2 anchorPosition = new Vector2(screenPosition.x - (canvasPos.sizeDelta.x * 0.5f),
                screenPosition.y - (canvasPos.sizeDelta.y * 0.5f) + yOffset);
        _trashBinBarPosition.anchoredPosition = anchorPosition;
    }
}
