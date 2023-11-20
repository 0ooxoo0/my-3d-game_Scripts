using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadAndSaveSystemInventary : MonoBehaviour
{
    public GameObject Slots;
    public GameObject InventarySlots;
    public ItemScriptableObject item1;
    public ItemScriptableObject item2;
    public ItemScriptableObject item3;
    public InventoryManager IM;
    bool save = false;
    bool load = true;
    void Start()
    {

    }

    private void Update()
    {
        if(load == true)
        {
            IM.UIBG.SetActive(true);
            IM.GO.SetActive(true);
            int CaildNumberSlots = Slots.transform.childCount;
            int CaildNumberInventarySlots = InventarySlots.transform.childCount;

            for (int i = 0; i < CaildNumberSlots; i++)
            {
                if (File.Exists(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                {
                    if (File.ReadAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") != "")
                    {
                        if (item1.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item1 != null)
                        {
                            Slots.transform.GetChild(i).GetComponent<InventorySlot>().item = item1;
                        }
                        else if (item2.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item2 != null)
                        {
                            Slots.transform.GetChild(i).GetComponent<InventorySlot>().item = item2;
                        }
                        else if (item3.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item3 != null)
                        {
                            Slots.transform.GetChild(i).GetComponent<InventorySlot>().item = item3;
                        }
                        Slots.transform.GetChild(i).GetComponent<InventorySlot>().amount = int.Parse(File.ReadAllText(Application.persistentDataPath + "/InventaryItemItemAmout" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                    }
                }
            }
            for (int i = 0; i < CaildNumberInventarySlots; i++)
            {
                if (File.Exists(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                {
                    if (File.ReadAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") != "")
                    {
                        if (item1.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item1 != null)
                        {
                            InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item = item1;
                        }
                        else if (item2.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item2 != null)
                        {
                            InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item = item2;
                        }
                        else if (item3.name == File.ReadAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && item3 != null)
                        {
                            InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item = item3;
                        }

                        File.WriteAllText(Application.persistentDataPath + "/InventaryItemItemBronyiaAmout" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().amount);
                    }
                }
            }
            IM.UIBG.SetActive(false);
            IM.GO.SetActive(false);
            load = false;
        }
        if(save == true)
        {
            IM.UIBG.SetActive(true);
            IM.GO.SetActive(true);
            int CaildNumberSlots = Slots.transform.childCount;
            int CaildNumberInventarySlots = InventarySlots.transform.childCount;
            for (int i = 0; i < CaildNumberSlots; i++)
            {
                //Debug.Log("Save");
                if (Slots.transform.GetChild(i).GetComponent<InventorySlot>().item != null)
                {
                    if (item1.name == Slots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item1 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item1.name);
                    else if (item2.name == Slots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item2 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item2.name);
                    else if (item3.name == Slots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item3 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item3.name);
                    
                    File.WriteAllText(Application.persistentDataPath + "/InventaryItemItemAmout" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + Slots.transform.GetChild(i).GetComponent<InventorySlot>().amount);
                }
                else
                {
                    File.WriteAllText(Application.persistentDataPath + "/InventaryItem" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "");
                }
            }
            for (int i = 0; i < CaildNumberInventarySlots; i++)
            {
                if (InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item != null)
                {
                    if (item1.name == InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item1 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item1.name);
                    else if (item2.name == InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item2 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item2.name);
                    else if (item3.name == InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().item.name && item3 != null)
                        File.WriteAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + item3.name);

                    File.WriteAllText(Application.persistentDataPath + "/InventaryItemItemBronyiaAmout" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + InventarySlots.transform.GetChild(i).GetComponent<InventorySlot>().amount);
                }
                else
                {
                    File.WriteAllText(Application.persistentDataPath + "/InventaryItemBronyia" + i + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "");
                }
            }
            IM.UIBG.SetActive(false);
            IM.GO.SetActive(false);
            save = false;
        }
    }
    public void Save()
    {
        save= true;
    }
    public void Load()
    {
        load= true;
    }
}
