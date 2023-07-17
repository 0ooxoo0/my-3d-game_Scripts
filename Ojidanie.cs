using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Using;
using VolumetricClouds3;

public class Ojidanie : MonoBehaviour
{
    public GameObject player;
    public GameObject camm;
    public DayCycleManager DCM;
    public Slider slider;
    public GameObject OjidaemPrefab;
    public bool Ojidaem;
    public float tm = 5;
    public LifeBarScript life;
    public GameObject panel;
    public RaymarchedClouds oblako;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OjidaemPrefab.active == true)
        {
            OjidanieTrue();
        }

        if (Ojidaem == false)
        {
            if (Input.GetMouseButton(0))
            {
                tm = 5f;
            }
            else
            {
                if (tm <= 0)
                    DSManager();
                if (tm > 0)
                    tm -= Time.deltaTime;
            }
        }

        if (DCM.TimeOfDay > slider.value && DCM.TimeOfDay < slider.value + 0.05f)
        {
            slider.value = DCM.TimeOfDay;
        }
        if(Ojidaem == true && DCM.TimeOfDay != slider.value)
        {
            DCM.DayDuration = 10f;
        }
        if(DCM.TimeOfDay == slider.value)
        {
            Ojidaem = false;
            DCM.DayDuration = 600f;
            life.estusFlask = LifeBarScript.MaxEstusFlask;
                life.Save();
        }
    }

    void LateUpdate()
    {
        if (OjidaemPrefab.active == true)
        {
            OjidanieTrue();
        }
    }

    public void DSManager()
    {
        slider.value = DCM.TimeOfDay;
    }

    public void VKLOjidanie ()
    {
        Ojidaem = true;
    }
    public void OjidanieTrue()
    {
        camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
        camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<GirlScript>().Molitva = true;
        GirlSoundsScript.anim.SetFloat("Speed",0); 
        panel.SetActive(true);
    }
    public void OjidanieFalse()
    {
        camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 2;
        camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 5;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<GirlScript>().Molitva = false;
        panel.SetActive(false);
    }
}
