using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    //public GameObject crosshair;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 3f;
    private Camera mainCamera;
    public BlurOptimized blur;
    public GameObject GO;

    // Start is called before the first frame update
    private void Awake()
    {
        UIBG.SetActive(true);
    }
    void Start()
    {
        mainCamera = Camera.main;
        for(int i = 0; i < inventoryPanel.childCount; i++)
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIBG.SetActive(false);
        GO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.gameObject.SetActive(false);
            blur.enabled = false;
            Pause_menu.active = false;
            UIBG.SetActive(false);
            GO.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;

            if (isOpened)
            {
                inventoryPanel.gameObject.SetActive(true);
                blur.enabled= true;
                Pause_menu.active = true;
                UIBG.SetActive(true);
                GO.SetActive(true);
                //crosshair.SetActive(false);
            }
            else
            {
                inventoryPanel.gameObject.SetActive(false);
                blur.enabled = false;
                Pause_menu.active = false;
                UIBG.SetActive(false);
                GO.SetActive(false);
                //crosshair.SetActive(true);
            }
        }
    }

    public void InventoryOpen()
    {
        isOpened = true;    
        inventoryPanel.gameObject.SetActive(true);
        blur.enabled = true;
        Pause_menu.active = true;
        UIBG.SetActive(true);
        GO.SetActive(true);
    }
    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if(slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}
