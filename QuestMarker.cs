using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestMarker : MonoBehaviour
{
    public GameObject marker;
    public string NameDelite;
    public Sprite icon;
    public Image image;
    public bool act = false;
    public float a;
    public float b;
    public float g;
    public float r;
    public int i;
    public float tm = 1f;
    public float tim = 2.2f;
    bool por = true;
    public GameObject Player;
    public GameObject mark;
    public Image markm;
    public float distanse;
    public bool tochkaNaKarte = false;
    public bool Stroeniya = false;
    public bool save = true;
    float time = 0.5f;
    private void Start()
    {
        Player = GameObject.Find("Girl");
    }
    void Update()
    {
        if (Player == null)
            Player = GameObject.Find("Girl");


        if(time > 0)
            time -= Time.deltaTime;

        if(save == true && Stroeniya == true && time<=0)
        {
            Debug.Log("1" + gameObject.name);
            if(File.Exists(Application.persistentDataPath + "/" + gameObject.name + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            {
                Debug.Log("2" + gameObject.name);
                if (File.ReadAllText(Application.persistentDataPath + "/" + gameObject.name + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") == "1")
                {
                    Debug.Log("3" + gameObject.name);
                    DeleteMarker();
                    save = false;
                    Debug.Log(save);
                }
            }
            else
                save = false;
        }

        if (marker!= null && Stroeniya == false)
        {
            distanse = Vector3.Distance(gameObject.transform.position, Player.transform.position);
            if (tochkaNaKarte == false)
            {
                if (distanse < 20 && act == false)
                {
                    mark.SetActive(true);
                    if (r < 1f)
                        r = (1 - ((distanse * 4) / 100));
                    markm.color = new Vector4(1, 1, 1, r);
                }
                if (distanse > 20 && act == false)
                {
                    if (r > 0)
                        r = (1 - ((distanse * 4) / 100));
                    markm.color = new Vector4(1, 1, 1, r);
                }
                if (distanse > 25 && act == false)
                {
                    r = 1;
                    mark.SetActive(false);
                }
            }
        }
        if (act == true)
        {
            if (tochkaNaKarte == false)
            {
                if (tim > 0)
                {
                    tim -= Time.deltaTime;
                    if (r >= 0.9 || por == true)
                    {
                        por = true;
                        r -= Time.deltaTime * 3;
                        image.color = new Vector4(1, 1, 1, r);
                        if (Stroeniya == false)
                            markm.color = new Vector4(1, 1, 1, r);
                    }
                    if (r <= 0.1 || por == false)
                    {
                        por = false;
                        r += Time.deltaTime * 3;
                        image.color = new Vector4(1, 1, 1, r);
                        if (Stroeniya == false)
                            markm.color = new Vector4(1, 1, 1, r);
                    }
                }
                else
                {
                    act = false;
                    r = 1;
                    image.color = new Vector4(1, 1, 1, 1);
                    if (Stroeniya == false)
                        markm.color = new Vector4(1, 1, 1, 1);
                    tim = 2.2f;
                }
            }
        }
    }
    public Vector2 position
    {
        get { return new Vector2(transform.position.x, transform.position.z); }
    }
    public void DeleteMarker()
    {
        Destroy(marker);
        Destroy(GameObject.Find(NameDelite)); 
        if (tochkaNaKarte == false && mark != null)
            mark.SetActive(false);
        if (tochkaNaKarte == false && markm != null)
            markm.enabled = false;

        if (Stroeniya == true)
        File.WriteAllText(Application.persistentDataPath + "/" + gameObject.name + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt", "1");
    }

    public void ACtive()
    {
        act = true;
        if (marker == null)
        {
            marker = GameObject.Find("Arrow(Clone)");
            marker.name = ("Arrow(Clone)" + gameObject.name);
            marker = GameObject.Find("Arrow(Clone)" + gameObject.name);
            image = marker.GetComponent<Image>();
            if (tochkaNaKarte == false)
                markm.enabled = true;
        }
    }

    public void activeMarker()
    {
        if (marker == null)
        {
            marker = GameObject.Find("Arrow(Clone)");
            marker.name = ("Arrow(Clone)" + gameObject.name);
            marker = GameObject.Find("Arrow(Clone)" + gameObject.name);
            image = marker.GetComponent<Image>();
            if (tochkaNaKarte == false)
                markm.enabled= true;
        }
    }
}
