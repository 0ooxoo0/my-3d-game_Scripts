using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Using;
/// IPointerDownHandler - Следит за нажатиями мышки по объекту на котором висит этот скрипт
/// IPointerUpHandler - Следит за отпусканием мышки по объекту на котором висит этот скрипт
/// IDragHandler - Следит за тем не водим ли мы нажатую мышку по объекту
public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InventorySlot oldSlot;
    private Transform player;
    public GameObject Usinggg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Находим скрипт InventorySlot в слоте в иерархии
        oldSlot = transform.GetComponentInParent<InventorySlot>();
        Usinggg = GameObject.Find("Использоватьь");
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            // Если слот пустой, то мы не выполняем то что ниже return;
            if (oldSlot.isEmpty)
                return;
            GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (oldSlot.isEmpty)
                return;

            //Делаем картинку прозрачнее
            GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
            // Делаем так чтобы нажатия мышкой не игнорировали эту картинку
            GetComponentInChildren<Image>().raycastTarget = false;
            // Делаем наш DraggableObject ребенком InventoryPanel чтобы DraggableObject был над другими слотами инвенторя
            transform.SetParent(transform.parent.parent);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (oldSlot.isEmpty)
                return;

            // Делаем картинку опять не прозрачной
            GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
            // И чтобы мышка опять могла ее засечь
            GetComponentInChildren<Image>().raycastTarget = true;

            //Поставить DraggableObject обратно в свой старый слот
            transform.SetParent(oldSlot.transform);
            transform.position = oldSlot.transform.position;
            //Если мышка отпущена над объектом по имени UIPanel, то...
            if (eventData.pointerCurrentRaycast.gameObject.name == "Использоватьь" && oldSlot.item.itemType == ItemType.Healing)
            {
                if (LifeBarScript.life < LifeBarScript.MaxLife)
                {
                    if (oldSlot.amount > 1)
                        oldSlot.amount -= 1;
                    else
                        NullifySlotData();
                    if (LifeBarScript.life <= LifeBarScript.MaxLife - 5)
                        LifeBarScript.life += 5;
                    else
                        LifeBarScript.life = LifeBarScript.MaxLife;
                }
                else
                {
                    Debug.Log("HP полные");
                }
            }
                if (eventData.pointerCurrentRaycast.gameObject.name == "UIBG")
            {
                // Выброс объектов из инвентаря - Спавним префаб обекта перед персонажем
                GameObject itemObject = Instantiate(oldSlot.item.itemPrefab, player.position + (Vector3.up * 0.2f) + player.forward, Quaternion.identity);
                // Устанавливаем количество объектов такое какое было в слоте
                itemObject.GetComponent<Item>().amount = oldSlot.amount;
                // убираем значения InventorySlot
                NullifySlotData();
            }
            else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>().isEmpty == true && eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>().TolcoDlaRun == false)
            {
                //Перемещаем данные из одного слота в другой
                ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
            }
            if (oldSlot.item.itemType == ItemType.АrmorRuns)
            {
                ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
            }
        }
    }
    void NullifySlotData()
    {
        // убираем значения InventorySlot
        oldSlot.item = null;
        oldSlot.amount = 0;
        oldSlot.isEmpty = true;
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.iconGO.GetComponent<Image>().sprite = null;
        oldSlot.itemAmountText.text = "";
    }
    void ExchangeSlotData(InventorySlot newSlot)
    {
        // Временно храним данные newSlot в отдельных переменных
        ItemScriptableObject item = newSlot.item;
        int amount = newSlot.amount;
        bool isEmpty = newSlot.isEmpty;
        GameObject iconGO = newSlot.iconGO;
        TMP_Text itemAmountText = newSlot.itemAmountText;

        // Заменяем значения newSlot на значения oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;
        if (oldSlot.isEmpty == false)
        {
            newSlot.SetIcon(oldSlot.iconGO.GetComponent<Image>().sprite);
        }
        else
        {
            newSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            newSlot.iconGO.GetComponent<Image>().sprite = null;
        }
        
        newSlot.isEmpty = oldSlot.isEmpty;

        // Заменяем значения oldSlot на значения newSlot сохраненные в переменных
        oldSlot.item = item;
        oldSlot.amount = amount;
        if (isEmpty == false)
        {
            oldSlot.SetIcon(iconGO.GetComponent<Image>().sprite);

        }
        else
        {
            oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            oldSlot.iconGO.GetComponent<Image>().sprite = null;
        }
        
        oldSlot.isEmpty = isEmpty;
    }
}
