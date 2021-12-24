using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player, bullet, muzzleFlash;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isIdle = false, isShooting = false;
    private Vector3 currentTarget;
    public AudioSource shootSound;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && !isIdle)
        {
            //    NavMeshAgent closestZombie = findClosestAgent();
            //    NavMeshAgent closestPlayer = findClosestAgent();

            /*
                    if (Vector3.Distance(agent.transform.position, closestZombie.transform.position) < 5)
                    {
                        // kill zombie
                    }
                    else*/

            RaycastHit hit;
            // If close enough to player
            if (Vector3.Distance(agent.transform.position, player.transform.position) < 50)
            {
                // turn agent's head to player location
                agent.transform.LookAt(new Vector3(player.transform.position.x, agent.transform.position.y, player.transform.position.z));

                // If has the player on sight, shoot..
                if (Physics.Raycast(agent.transform.position, (player.transform.position - agent.transform.position).normalized, out hit) && hit.collider.tag == "Player")
                {
                    agent.velocity = Vector3.zero; // Stop agent speed
                    if (!isShooting)
                    {
                        StartCoroutine(ShowFlash());
                        StartCoroutine(simulateShoot());
                    }
                }
                else // Does not have the player on sight but still close to him, update destination and walk.
                {
                    animator.SetInteger("NPCmode", 1);
                    agent.SetDestination(player.transform.position);
                }
            }
            else // The player is far away get the closest target
            {
                animator.SetInteger("NPCmode", 1);
                agent.SetDestination(player.transform.position);
            }
        }
    }

    IEnumerator simulateShoot()
    {
        isShooting = true;
        int hitChance = Random.Range(0, 100);
        if (agent.enabled)
        {
            animator.SetInteger("NPCmode", 2);
            shootSound.Play();
            if (hitChance >= 55)
            {
                bullet.SetActive(true);
                bullet.transform.position = player.transform.position;
            }
            // else missed
        }
        yield return new WaitForSeconds(1.5f);
        isShooting = false;
    }

    IEnumerator ShowFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.05f);
    }
}
