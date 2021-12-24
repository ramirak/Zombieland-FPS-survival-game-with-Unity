using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCmotion : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] targets = new GameObject[4];
    private Animator animator;
    private int currentTarget;
    private bool isIdle = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        this.currentTarget = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && !isIdle)
        {
            if (Vector3.Distance(agent.transform.position, targets[currentTarget].transform.position) < 2f)
            {
                isIdle = true;
                StartCoroutine(goIdle());

            }
            agent.SetDestination(targets[currentTarget].transform.position);
        }
    }

    IEnumerator goIdle()
    {
        animator.SetInteger("NPCmode", 0); // Idle
        agent.velocity = Vector3.zero;
        if (agent.enabled)
            agent.Stop();

        yield return new WaitForSeconds(10f); if (agent.enabled)
            agent.Resume();
        animator.SetInteger("NPCmode", 1); // walk
        currentTarget++;
        if (currentTarget >= targets.Length)
            currentTarget = 0;
        if (agent.enabled)
            agent.SetDestination(targets[currentTarget].transform.position);
        isIdle = false;
    }

}
