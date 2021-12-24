using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    public GameObject player, center;
    private float maxDistance = 100;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isIdle = false;
    private AudioSource zombieSound;
    private Vector3 currentTarget;
    private const float shortDistance = 30, longDistance = 60;
    private float huntDistance = shortDistance;
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieSound = GetComponent<AudioSource>();
        currentTarget = getRandomDestination();

    }


    void draw()
    {
        if (agent.path.corners != null && agent.path.corners.Length > 1)
        {
            lineRenderer.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
            {
                lineRenderer.SetPosition(i, agent.path.corners[i]);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // draw();
        if (agent.enabled && !isIdle)
        {
            // Hunt the player if he is close enough
            if (Vector3.Distance(agent.transform.position, player.transform.position) < huntDistance)
            {
                // keep hunting even if the player is getting away
                huntDistance = longDistance;
                agent.SetDestination(player.transform.position);
                //animator.SetInteger("NPCmode", 1); // walk
            }
            else // Wander around the city constantly 
            {
                agent.SetDestination(currentTarget);
                int counter = 10;
                while (agent.pathStatus == NavMeshPathStatus.PathInvalid || agent.pathStatus == NavMeshPathStatus.PathPartial)
                {                    // Target is unreachable
                    currentTarget = getRandomDestination();
                    counter--;
                    if (counter == 0)
                        break;
                }

                if (Vector3.Distance(agent.transform.position, currentTarget) < 4f)
                {
                    currentTarget = getRandomDestination(); // Get next target
                                                            //      isIdle = true;
                                                            //      StartCoroutine(goIdle());
                }
                //     animator.SetInteger("NPCmode", 1); // walk
            }
        }
    }

    Vector3 getRandomDestination()
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center.transform.position;
        NavMeshHit hit; // NavMesh Sampling Info Container
        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        Vector3 vector = new Vector3(hit.position.x, this.transform.position.y, hit.position.z);
        return vector; // or return hit.position where y is random
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetInteger("NPCmode", 2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetInteger("NPCmode", 1);

    }


    IEnumerator goIdle()
    {
        animator.SetInteger("NPCmode", 0); // Idle
        agent.velocity = Vector3.zero; // Stop agent speed
        if (agent.enabled) // Check if the agent has not died during idle time then stop him.
            agent.Stop();
        yield return new WaitForSeconds(10f);
        if (agent.enabled)
            agent.Resume();
        isIdle = false;
    }

}
