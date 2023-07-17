using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LoadGame : MonoBehaviour
{
    //public GameObject RawImage;
    public float Tim = 20;
    public float exp;
    public float NeedExp;
    public int Levl;
    //public TextMeshProUGUI LoadingPercentage;
    public Slider LoadingProgressBar;

    private static LoadGame instance;
    //private static bool shouldPlayOpeningAnimation = false;

    //private Animator componentAnimator;
    public AsyncOperation loadingSceneOperation;
    public Slider LevelBar;
    public TextMeshProUGUI LevelText;
    public GameObject[] GO;

    bool Loadf = false;

    public void SwitchToScene(string sceneName)
    {
        if (File.Exists(Application.persistentDataPath + "/VosholVPodzemelie" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            sceneName = "1";
        if (File.Exists(Application.persistentDataPath + "/VosholVFinalBoss" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            sceneName = "FinalBoss";
            //instance.componentAnimator.SetTrigger("sceneClosing");
            instance = this;
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        // Чтобы сцена не начала переключаться пока играет анимация closing:
        instance.loadingSceneOperation.allowSceneActivation = false;

        instance.LoadingProgressBar.value = 0;
    }

    public void Start()
    {
        instance = this;
        GO[Random.Range(0, GO.Length)].SetActive(true);
        //componentAnimator = GetComponent<Animator>();

        //if (shouldPlayOpeningAnimation)
        //{
        //    componentAnimator.SetTrigger("sceneOpening");
            //instance.LoadingProgressBar.value = 1;

        //    // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
        //    shouldPlayOpeningAnimation = false;
        //}
            //if(File.Exists(Application.persistentDataPath + "/Levl" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
            //{
            //    Load();
            //    LevelText.text = "" + Levl;
            //    LevelBar.value = exp / NeedExp;
            //}
        }

        public void FixedUpdate()
    {
        if (Loadf == false && File.Exists(Application.persistentDataPath + "/Levl" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"))
        {
            //RawImage.SetActive(true);
            Load();
            LevelText.text = "" + Levl;
            LevelBar.value = exp / NeedExp;
            Loadf= true;
        }
        if (loadingSceneOperation != null)
        {
            if (Tim > 0)
                Tim -= Time.deltaTime;
            if (Tim <= 0)
            {
                Tim = 20;
                instance.loadingSceneOperation.allowSceneActivation = true;
            }
            //LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";

            // Просто присвоить прогресс:
            //LoadingProgressBar.value = loadingSceneOperation.progress; 

            // Присвоить прогресс с быстрой анимацией, чтобы ощущалось плавнее:
            instance.LoadingProgressBar.value = Mathf.Lerp(LoadingProgressBar.value, loadingSceneOperation.progress, Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        //shouldPlayOpeningAnimation = true;

        //loadingSceneOperation.allowSceneActivation = true;
    }
    public void Load()
    {
        exp = float.Parse(File.ReadAllText(Application.persistentDataPath + "/exp" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
        Levl = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Levl" + ("" + 0 + PlayerPrefs.GetInt("SaveBlock")) + Application.version + ".txt"));
        NeedExp = Levl * 10;
    }
}
