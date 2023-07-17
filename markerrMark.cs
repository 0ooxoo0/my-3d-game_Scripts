using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class markerrMark : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject Dialog;
    public GameObject Object;
    public GameObject Luch;
    public GameObject LuchPrafab;
    public GameObject CF;
    public GameObject Dialoggggg;
    // Start is called before the first frame update
    void Start()
    {
        Dialog = GameObject.Find("Dialog");
        Object = GameObject.Find("Terrain (1)");
        CF = GameObject.Find("CompasFinal");
        this.transform.position = Input.mousePosition;
        Luch = Instantiate(LuchPrafab, Object.transform);
        Luch.transform.localPosition = new Vector3(transform.localPosition.x * 1.1f, 0, transform.localPosition.y * 1.1f);
        Luch.GetComponent<TochkkaNaKarte>().image = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Luch.GetComponent<QuestMarker>().marker == null || Luch.GetComponent<QuestMarker>().image == null)
        {
            CF.GetComponent<CompasFinal>().AddQuestMarker(Luch.GetComponent<QuestMarker>());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Dialog.SetActive(true);
        Dialog.GetComponent<Dialogmm>().marker = this.gameObject;
        Dialog.GetComponent<Dialogmm>().MarkerrMarkk = this.GetComponent<markerrMark>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void LuchDeleted()
    {
        CF.GetComponent<CompasFinal>().DeleteQuestMarker(Luch.GetComponent<QuestMarker>());
        CF.GetComponent<CompasFinal>().DeleteQuestMarker(this.GetComponent<QuestMarker>());
    }

    public void DialFalse()
    {
        Dialoggggg.SetActive(false);
    }
    public void DialTrue()
    {
        Dialoggggg.SetActive(true);
    }
}
