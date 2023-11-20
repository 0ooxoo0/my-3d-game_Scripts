using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public GameObject txt;
    public TMP_Text itemAmountText;
    public bool TolcoDlaRun;
    public GameObject UsingGGG;
    public bool active = false;

    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
        if (item.itemType != ItemType.АrmorRuns)
        {
            txt.SetActive(true);
        }
    }
    public void Update()
    {
        if(item!= null && active == false)
        {
            iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            iconGO.GetComponent<Image>().sprite = item.icon;
            if (item.itemType != ItemType.АrmorRuns)
            {
                txt.SetActive(true);
                txt.GetComponent<TextMeshProUGUI>().text = "" + amount;
            }
            isEmpty= false;
            active = true;
        }
        if(item == null && active == true)
        {
            isEmpty = true;
            active = false;
            txt.SetActive(false);
        }
    }
}
