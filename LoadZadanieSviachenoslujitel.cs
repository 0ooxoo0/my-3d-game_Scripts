using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadZadanieSviachenoslujitel : MonoBehaviour
{
    public bool load1 = true;
    public bool load2 = true;
    public CompasFinal CF;
    public QuestMarker SviachennoSlujitel;
    public QuestMarker Vicing;
    public ScrollViewAdapter Content;
    public QuestMarker RuiniStarogoGoroda;
    public QuestMarker RuiniSviatilishia;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/DialogSviachennoslygitel1" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && load1 == false)
        {
            if (File.Exists(Application.persistentDataPath + "/Vicing" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            { }
            else
            {
                //CF.DeleteQuestMarker(SviachennoSlujitel);
                //SviachennoSlujitel.DeleteMarker();
                CF.AddQuestMarker(Vicing);
                Content.UpdateItems(3);
            }
            load1 = true;
        }
        if (File.Exists(Application.persistentDataPath + "/DialogSviachennoslygitel2" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt") && load2 == false)
        {
            if (File.Exists(Application.persistentDataPath + "/MapTpBool" + "3" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            { }
            else
            {
                CF.AddQuestMarker(RuiniStarogoGoroda);
                Content.UpdateItems(4);
            }
            if (File.Exists(Application.persistentDataPath + "/MapTpBool" + "3" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            { }
            else
            {
                CF.AddQuestMarker(RuiniSviatilishia);
                Content.UpdateItems(5);
            }
            load2 = true;
        }
    }

    public void LoadTru1()
    {
        load1 = true;
    }
    public void LoadTru2()
    {
        load2 = true;
    }
}
