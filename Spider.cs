using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    public List<Transform> targets;
    NavMeshAgent agent;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[i].position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TargetUpdate()
    {
        if (i < targets.Count)
        {
            i++;
        }
        else
        {
            i = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpiderPoint")
        {
            TargetUpdate();
            agent.SetDestination(targets[i].position);
        }
    }
}
