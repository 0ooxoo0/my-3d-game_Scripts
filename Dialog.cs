using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class Dialog : MonoBehaviour
{
    public Jitel jitel;
    public string ImiaCheloveka; 
    public GameObject DD;
    public TextMeshProUGUI text;
    public string NameSave1;
    public string NameSave2;
    public int active = 1;
    public int active1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        jitel = this.GetComponent<Jitel>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ImiaCheloveka;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (File.Exists(Application.persistentDataPath + "/" + NameSave1 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            {
                if (File.Exists(Application.persistentDataPath + "/" + NameSave2 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                {
                    active = int.Parse(File.ReadAllText(Application.persistentDataPath + "/" + NameSave1 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                    active1 = int.Parse(File.ReadAllText(Application.persistentDataPath + "/" + NameSave2 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                    if (active == 0 && active1 == 0)
                    {
                        DD.SetActive(false);
                        jitel.active = false;
                    }
                    else
                        DD.SetActive(true);
                }
                else
                    DD.SetActive(true);
            }
            else
                DD.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (other.tag == "Player")
            {
                Debug.Log("Player");
                if (File.Exists(Application.persistentDataPath + "/" + NameSave1 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                {
                    Debug.Log("1true");
                    if (File.Exists(Application.persistentDataPath + "/" + NameSave2 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
                    {
                        Debug.Log("2true");
                        int activ = int.Parse(File.ReadAllText(Application.persistentDataPath + "/" + NameSave1 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                        if (activ == 0)
                            DD.SetActive(false);
                        activ = int.Parse(File.ReadAllText(Application.persistentDataPath + "/" + NameSave2 + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                        if (activ == 0)
                            DD.SetActive(false);
                    }
                }
                else
                    DD.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            DD.SetActive(false);
    }
}
