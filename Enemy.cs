using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using UnityEngine.UI;


namespace Using
{
[RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        public GameObject player;
        public float timeDead;
        public GameObject removed;
        public GameObject removedHP;
        public bool pufkingRun = false;
        public GameObject tt;
        public Image RedImage;
        public GameObject HP;
        public Vector3 target;
        public Transform Parking;
        private Animator myAnimator;
        private NavMeshAgent myAgent;
        public float distance;
        public float distanceParking;
        public float damage = 1;
        public static float EnemyDamage;
        public float MaxLife = 10;
        public static float life;
        public float Live;
        public GameObject bloodPrefab;
        public GameObject bloodSoundPrefab;
        public Transform bloodPos;
        public Animator ButtonAnim;
        float y;
        float w;
        public bool peshera = false;

        public bool Vipadeniee = true;
        public ItemScriptableObject[] item;


        void Start()
        {
            player = GameObject.Find("SSS");
            life = MaxLife;
            Live = life;
            RedImage.fillAmount = ((Live * 100) / MaxLife)/100;
            EnemyDamage = damage;
            transform.LookAt(target);
            myAgent = GetComponent<NavMeshAgent>();
            myAnimator = this.GetComponent<Animator>();
            ButtonAnim = HP.GetComponent<Animator>();
            if(peshera == true) 
                Vipadeniee = false;
        }

        void Update()
        {
            if (myAnimator.GetBool("Dead") == true)
            {
                if(peshera == true)
                timeDead -= Time.deltaTime;
                if (timeDead <= 180f)
                {
                    removed.SetActive(false);
                }
                if (timeDead <= 0)
                {
                    myAnimator.SetBool("Dead", false);
                    removedHP.SetActive(true);
                    removed.SetActive(true);
                    Live = MaxLife;
                    RedImage.fillAmount = ((Live * 100) / MaxLife) / 100;
                }
            }
            else
            {
                    target = player.transform.position;
                    y = transform.rotation.y;
                    w = transform.rotation.w;
                    transform.rotation = new Quaternion(0, y, 0, w);
                    distanceParking = Vector3.Distance(Parking.position, transform.position);
                    if (LifeBarScript.life > 0)
                        distance = Vector3.Distance(target, transform.position);
                    if (LifeBarScript.life <= 0)
                        distance = 20;
                    if (distance > 10 && pufkingRun == false)
                    {
                        ButtonAnim.SetBool("Start", false);
                        myAgent.enabled = false;
                        myAnimator.SetBool("Attak", false);
                        myAnimator.SetBool("Run", false);
                        myAnimator.SetBool("Idle", true);
                    }

                    if (distanceParking < 0.5)
                    {
                        pufkingRun = false;
                    }

                    if (distanceParking > 15)
                    {
                        pufkingRun = true;
                        Live = MaxLife;
                        RedImage.fillAmount = ((Live * 100) / MaxLife) / 100;
                        ButtonAnim.SetBool("Destoy", false);
                        transform.LookAt(Parking);
                        myAgent.enabled = true;
                        myAgent.SetDestination(Parking.position);
                        myAnimator.SetBool("Attak", false);
                        myAnimator.SetBool("Idle", false);
                        myAnimator.SetBool("Run", true);
                        ButtonAnim.SetBool("Start", true);
                    }

                    if (distance < 10 && myAnimator.GetBool("Attak") == false && pufkingRun == false)
                    {
                        ButtonAnim.SetBool("Destoy", false);
                        transform.LookAt(target);
                        myAgent.enabled = true;
                        myAgent.SetDestination(target);
                        myAnimator.SetBool("Attak", false);
                        myAnimator.SetBool("Idle", false);
                        myAnimator.SetBool("Run", true);
                        ButtonAnim.SetBool("Start", true);
                    }
                    if (distance < 2 && LifeBarScript.life > 0 && pufkingRun == false)
                    {
                        transform.LookAt(target);
                        myAgent.enabled = false;
                        myAnimator.SetBool("Idle", false);
                        myAnimator.SetBool("Run", false);
                        myAnimator.SetBool("Attak", true);
                    }
                    y = transform.rotation.y;
                    w = transform.rotation.w;
                    transform.rotation = new Quaternion(0, y, 0, w);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" && distance <= 2f && Live > 0 && pufkingRun == false)
            {
                myAnimator.SetBool("Attak", true);
                transform.LookAt(target);
                y = transform.rotation.y;
                w = transform.rotation.w;
                transform.rotation = new Quaternion(0, y, 0, w);
            }
            else
            {
                myAnimator.SetBool("Attak", false);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && Live > 0 && pufkingRun == false)
            {
                myAnimator.SetBool("Attak", false);
            }
            if(other.tag == "Sword" && Live > 0 && pufkingRun == false)
            {
                Live -= LevelUp.Damage;
                RedImage.fillAmount = ((Live * 100) / MaxLife)/100;
                GameObject blood = Instantiate(bloodPrefab, bloodPos.position, Quaternion.identity);
                blood.transform.LookAt(target);
                Destroy(blood, 0.2f);
                blood = Instantiate(bloodSoundPrefab, bloodPos.position, Quaternion.identity);
                blood.transform.LookAt(target);
                Destroy(blood, 2f);

                if (Live<=0)
                {
                    Live = 0;
                    if(Vipadeniee == true)
                    {
                        Debug.Log(item.Length);
                        int rand = Random.Range(0, item.Length);
                        GameObject itemObject = Instantiate(item[rand].itemPrefab, this.transform.position, Quaternion.identity);
                        if (item[rand].itemType == ItemType.ÀrmorRuns)
                        {
                            itemObject.GetComponent<Item>().amount = 1;
                        }
                        else
                        {
                            itemObject.GetComponent<Item>().amount = Random.Range(1, 3);
                        }
                    }
                    myAnimator.SetBool("Dead", true);
                    ButtonAnim.SetBool("Dead", true);
                    LevelUp.exp += (10*LevelUp.MnojitelExpe);
                    removedHP.SetActive(false);
                    timeDead = (60 * 5);
                }
            }
        }
    }
}
