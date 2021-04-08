using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemUI : MonoBehaviour
{

    [Space(20f)]
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemNameText;
    [SerializeField] TMP_Text itemPriceText;
    [SerializeField] Button itemPurchaseButton;
    [SerializeField] TMP_Text purchasedText;

    //--------------------------------------------------------------
    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }

    public void SetItemName(string name)
    {
        itemNameText.text = name;
    }

    public void SetItemPrice(int price)
    {
        itemPriceText.text = price.ToString();
    }

    public void SetItemAsPurchased()
    {
        itemPurchaseButton.gameObject.SetActive(false);
        purchasedText.text = "Purchased";
    }

    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        itemPurchaseButton.onClick.RemoveAllListeners();
        itemPurchaseButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }
}
