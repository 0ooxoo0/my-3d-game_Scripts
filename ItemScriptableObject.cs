using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {Default,Weapon,АrmorRuns,Shops, Healing}
public class ItemScriptableObject : ScriptableObject
{
    
    public string itemName;
    public int maximumAmount;
    public GameObject itemPrefab;
    public Sprite icon;
    public ItemType itemType;
    public string itemDescription;
    public float healAmount;
    public float ArmorAmout;
    public float Gold;
}
