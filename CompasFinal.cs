using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CompasFinal : MonoBehaviour
{
    public GameObject iconPrefab;
    List<QuestMarker> questMarkers = new List<QuestMarker>();
    public RawImage CompassImage;
    public Transform player;
    float compassUnit;
    public QuestMarker qe;


    private void Start()
    {
        compassUnit = CompassImage.rectTransform.rect.width / 360f;
        if (File.Exists(Application.persistentDataPath + "/DialogSviachennoslygitel1" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
        {}
        else
            AddQuestMarker(qe);
    }
    void Update()
    {
        CompassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (QuestMarker marker in questMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
        }
    }

    public void AddQuestMarker (QuestMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, CompassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;
        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(QuestMarker marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        return new Vector2(compassUnit *angle, 0f);
    }
    public void DeleteQuestMarker (QuestMarker marker)
    {
        Destroy(marker.image);
        marker.image = null;
        marker.DeleteMarker();
        questMarkers.Remove(marker);
    }
}
