using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Using;
using System.IO;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class Pause_menu : MonoBehaviour
{
    public GameObject camm;
    public TextMeshProUGUI Points;
    public GameObject Button;
    public GameObject Settings;
    public GameObject SettingsGraphic;
    public GameObject SettingsVolume;
    public GameObject Naviki;
    public GameObject Karta;
    public AudioMixer audioMixerButton;
    public AudioMixer audioMixerOcrujenie;
    public AudioMixer audioMixerFiht;
    public AudioMixer audioMixerMove;
    public GameObject ClickMusic;
    public GameObject PauseMenu;
    public static bool active = false;
    public bool actives = false;
    public float time;
    public GameObject Ojidanie;
    public GameObject FPS;
    public Toggle FPSToggle;
    public GameObject Vzlom;
    public GameObject SettingsMouse;
    bool act = true;
    public GirlSoundsScript girl;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            FPS.SetActive(bool.Parse(File.ReadAllText(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt")));
        FPSToggle.isOn = FPS.active;
        active = false;
    }

    void Update()
    {
        if (FPS.active != FPSToggle.isOn)
        {
            FPS.SetActive(FPSToggle.isOn);
            File.WriteAllText(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + FPS.active);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            Ojidanie.SetActive(true);
            Ojidanie.GetComponent<Ojidanie>().OjidanieFalse();
            Ojidanie.GetComponent<Ojidanie>().DSManager();
        }
        if (PauseMenu.activeInHierarchy)
        {}
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) && active == false)
            {
                camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
                camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftAlt) && active == false)
            {
                camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 2;
                camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 5;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (active == true)
        {
            camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
            camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            Points.text = "" + LevelUp.LevlPoints;
        actives = active;
        if (time>0)
        {
            time -= Time.deltaTime;
        }
        if(time<0)
        {
            time = 0;
        }
        if (active == false && Input.GetKeyDown(KeyCode.Escape) && time == 0)
        {
            PauseMenu.SetActive(true);
            Button.SetActive(true);
            Settings.SetActive(false);
            SettingsGraphic.SetActive(false);
            SettingsVolume.SetActive(false);
            Naviki.SetActive(false);
            Karta.SetActive(false);
            SettingsMouse.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            active = true;
            time = 0.1f;
            camm.SetActive(true);
            camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = girl.MaxVelosityY;
            camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = girl.MaxVelosityX;
        }
        if(active == true && Input.GetKeyDown(KeyCode.Escape) && time == 0)
        {
            if (File.Exists(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                FPS.SetActive(bool.Parse(File.ReadAllText(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt")));

            if (Settings.active == false && SettingsGraphic.active == false && SettingsVolume.active == false && Naviki.active == false && Karta.active == false && SettingsMouse.active == false)
            {
                PauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                active = false;
                time = 0.1f;
                camm.SetActive(false);
                camm.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = girl.MaxVelosityY;
                camm.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = girl.MaxVelosityX;
                Active();
                return;
            }
            if(SettingsGraphic.active == true)
            {
                SettingsGraphic.SetActive(false);
                return;
            }
            if(SettingsVolume.active == true)
            {
                SettingsVolume.SetActive(false);
                return;
            }
            if (Settings.active == true)
            {
                Settings.SetActive(false);
                return;
            }
            if (Naviki.active == true)
            {
                Naviki.SetActive(false);
                return;
            }
            if (Karta.active == true)
            {
                Karta.SetActive(false);
                return;
            }
            if (SettingsMouse.active == true)
            {
                //SettingsMouse.SetActive(false);
                return;
            }
        }
    }

    public void Click()
    {
        Instantiate(ClickMusic, gameObject.transform);
    }

    public void NextScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void Active()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        active = false;
        time = 0.1f;
    }

    public void QualityLoad(TMP_Dropdown DD)
    {
        DD.value = QualitySettings.GetQualityLevel();
    }
    public void FPSSave()
    {
            File.WriteAllText(Application.persistentDataPath + "/FPS" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + FPS.active);
    }
    public void VZLOM()
    {
        Vzlom.SetActive(true);
    }
    public void SaveSensivitySettings()
    {
        File.WriteAllText(Application.persistentDataPath + "/MouseVelosityX" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + SettingsMouse.transform.GetChild(3).GetComponent<Slider>().value);
        File.WriteAllText(Application.persistentDataPath + "/MouseVelosityY" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + SettingsMouse.transform.GetChild(4).GetComponent<Slider>().value);
    }
    public void LoadSensivitySettings()
    {
        if(File.Exists(Application.persistentDataPath + "/MouseVelosityX" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
        {
            SettingsMouse.transform.GetChild(3).GetComponent<Slider>().value = int.Parse(File.ReadAllText(Application.persistentDataPath + "/MouseVelosityX" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
            SettingsMouse.transform.GetChild(4).GetComponent<Slider>().value = int.Parse(File.ReadAllText(Application.persistentDataPath + "/MouseVelosityY" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
        }
        else
        {
            File.WriteAllText(Application.persistentDataPath + "/MouseVelosityX" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + 5);
            File.WriteAllText(Application.persistentDataPath + "/MouseVelosityY" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "" + 2);
            SettingsMouse.transform.GetChild(3).GetComponent<Slider>().value = int.Parse(File.ReadAllText(Application.persistentDataPath + "/MouseVelosityX" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
            SettingsMouse.transform.GetChild(4).GetComponent<Slider>().value = int.Parse(File.ReadAllText(Application.persistentDataPath + "/MouseVelosityY" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
        }
    }
}
