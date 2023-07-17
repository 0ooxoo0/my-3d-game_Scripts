using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class markerrMinimap : MonoBehaviour
{
    public GameObject MarkerPrefab;
    public GameObject Object;
    public List<GameObject> marker;
    public float time = 5f;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            marker.Add(Instantiate(MarkerPrefab, Object.transform));
        }
    }

}
