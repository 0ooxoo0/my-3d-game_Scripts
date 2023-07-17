using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{
    public List<Transform> targets;
    NavMeshAgent agent;
    public int i;
    public Animator anim;
    public bool stop;
    public float TM = 60;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (TM > 0)
        {
            TM -= Time.deltaTime;
            
        }
        if (TM <= 0 && anim.GetBool("STOP") == true)
                Go();
    }

    public void TargetUpdate()
    {
        if (i < targets.Count - 1)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        agent.SetDestination(targets[i].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpiderPoint")
        {
            TargetUpdate();
            agent.SetDestination(targets[i].position);
            if(other.name == "Stop")
            {
                agent.speed = 0f;
                anim.SetBool("GO", false);
                anim.SetBool("STOP", true);
                TM = 60;
            }
        }
    }
    public void Go()
    {
        TargetUpdate();
        anim.SetBool("STOP", false);
        anim.SetBool("GO", true);
        agent.speed = 50;
        
    }
}
