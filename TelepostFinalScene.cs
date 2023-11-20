using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Using;

public class TelepostFinalScene : MonoBehaviour
{
    public GameObject StatyiaDialog;
    public GirlScript player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (File.Exists(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            {
                int activ = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                if (activ == 1)
                    StatyiaDialog.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (File.Exists(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            {
                int activ = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
                if (activ == 1)
                    StatyiaDialog.SetActive(false);
            }
        }
    }
    public void Teleport()
    {
        if(File.Exists(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
        {
            int activ = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Final" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
            if(activ == 1)
            SceneManager.LoadScene("Son");
            Debug.Log(activ);
        }
    }
}
