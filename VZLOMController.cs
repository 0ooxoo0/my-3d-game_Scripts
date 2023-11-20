using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class VZLOMController : MonoBehaviour
{
    public float PolomcaOtmichki = 1;
    public GameObject VZLOM;
    GameObject Otmichka;
    public float mouseX;
    float mouseSens = 5;
    Quaternion originalRotation;
    float mouseXSave;
    bool a;
    public float nachalo;
    public float konec;
    public float LevelSlojnosti;
    public float NachalniyGradusVzloma;
    public float GradusZamka;
    public GameObject ZvucOtcritiyaZamka;
    public GameObject falseeee;
    public Image trueeee;
    public bool active;
    public float tm = 1;
    void Start()
    {
        if(LevelSlojnosti == 0)
            LevelSlojnosti= 1;
        if(NachalniyGradusVzloma== 0)
            NachalniyGradusVzloma= 5;
        originalRotation = transform.rotation;
        Otmichka = this.gameObject;
        nachalo = Random.Range(-135, 135 - ((NachalniyGradusVzloma / 100) * (100 + LevelSlojnosti)));
        konec = nachalo + ((NachalniyGradusVzloma / 100) * (100 + LevelSlojnosti));
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Pause_menu.active = false;
            mouseXSave= 0;
            mouseX= 0;
            VZLOM.SetActive(false);
        }
        Pause_menu.active = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        

        if (Input.GetMouseButton(0))
        {
            Quaternion rotarionX = Quaternion.AngleAxis(mouseX, Vector3.forward);
            transform.rotation = originalRotation * rotarionX;
            if(GradusZamka > -90 && mouseX > nachalo - 10 && mouseX < konec + 10)
            GradusZamka -= Time.deltaTime * 100;
            Quaternion rotarionZ = Quaternion.AngleAxis(GradusZamka, Vector3.forward);
            VZLOM.transform.rotation = rotarionZ;

            if (mouseX > nachalo && mouseX < konec && GradusZamka < -90 && active == false)
            {
                active = true;
                Instantiate(ZvucOtcritiyaZamka, this.transform);
                falseeee.SetActive(true);
                trueeee.enabled = false;
            }
            if (GradusZamka <= -90 || GradusZamka == 0)
            {
                a = true;
                if(mouseX < mouseXSave && a == true)
                {
                    mouseX += 1;
                    a= false;
                }
                if(mouseX > mouseXSave && a == true)
                {
                    mouseX -= 1;
                    a= false;
                }
                if (mouseX == mouseXSave)
                {
                    mouseX -= 0.5f;
                }

                PolomcaOtmichki -= Time.deltaTime;
            }
        }
        else
        {
            if (PolomcaOtmichki < 0)
            {
                VZLOM.SetActive(false);
                PolomcaOtmichki= 1;
            }

            if (GradusZamka < 0)
            {
                GradusZamka += Time.deltaTime * 200; 
                Quaternion rotarionZ = Quaternion.AngleAxis(GradusZamka, Vector3.forward);
                VZLOM.transform.rotation = rotarionZ;
            }
            if (GradusZamka > 0)
            {
                GradusZamka = 0; 
                Quaternion rotarionZ = Quaternion.AngleAxis(GradusZamka, Vector3.forward);
                VZLOM.transform.rotation = rotarionZ;
            }

            mouseX -= Input.GetAxis("Mouse X") * mouseSens;


            if (mouseX < -135)
            {
                mouseX = -135;
            }

            if (mouseX > 135)
            {
                mouseX = 135;
            }
            if(mouseX < 135 && mouseX > -135)
            {
                Quaternion rotarionX = Quaternion.AngleAxis(mouseX, Vector3.forward);
                transform.rotation = originalRotation * rotarionX;
                mouseXSave = mouseX;
            }
            if(tm < 0 && active == true)
            {
                tm = 1;
                VZLOM.SetActive(false);
            }
            if(tm > 0 && active == true)
                tm -= Time.deltaTime;
        }
    }
    public void Active()
    {
        if (LevelSlojnosti == 0)
            LevelSlojnosti = 1;
        if (NachalniyGradusVzloma == 0)
            NachalniyGradusVzloma = 5;
        originalRotation = transform.rotation;
        Otmichka = this.gameObject;
        nachalo = Random.Range(-135, 135 - ((NachalniyGradusVzloma / 100) * (100 + LevelSlojnosti)));
        konec = nachalo + ((NachalniyGradusVzloma / 100) * (100 + LevelSlojnosti));
    }
}
