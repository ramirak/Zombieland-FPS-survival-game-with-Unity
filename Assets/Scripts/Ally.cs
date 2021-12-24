using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    public GameObject zcityEntrance, bullet, muzzleFlash, fallbackLocation;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isIdle = false, isShooting = false;
    private Vector3 currentTarget;
    public AudioSource shootSound;
    private WavesManager wavesManager;
    public int shooterType; // 0 for allies, 1 for enemy 
    public float shootRate;
    public int successRate;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        wavesManager = zcityEntrance.GetComponent<WavesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && !isIdle)
        {
            NavMeshAgent closestZombie = GetClosestAgent(wavesManager.allZombies.ToArray());
            NavMeshAgent closestShooter;

            if (shooterType == 0)
                closestShooter = GetClosestAgent(wavesManager.allCleaners.ToArray());
            else
                closestShooter = GetClosestAgent(wavesManager.allAllies.ToArray());

            // Close to a zombie
            if (closestZombie != null && Vector3.Distance(agent.transform.position, closestZombie.transform.position) < 10)
            {
                prepareForBattle(closestZombie, "Zombie", 100);
            } // Too close to a shooter
            else if (closestShooter != null && Vector3.Distance(agent.transform.position, closestShooter.transform.position) < 50)
            {
                string enemyTag = shooterType == 0 ? "EnemyBody" : "Player";
                prepareForBattle(closestShooter, enemyTag, 30);
            } // Enemies are far away, move toward the closest one
            else if (closestShooter != null)
            {
                animator.SetInteger("NPCmode", 1);
                agent.SetDestination(closestShooter.transform.position);
            }
            else if (shooterType == 0 && Vector3.Distance(agent.transform.position, fallbackLocation.transform.position) > 10)
            {
                animator.SetInteger("NPCmode", 1);
                agent.SetDestination(fallbackLocation.transform.position);
            }
            else
            {
                animator.SetInteger("NPCmode", 0);
                agent.SetDestination(agent.transform.position);
            }

        }
    }

    void prepareForBattle(NavMeshAgent shootMe, string enemyTag, int dmg)
    {
        RaycastHit hit;
        // turn agent's head to enemy location
        agent.transform.LookAt(new Vector3(shootMe.transform.position.x, agent.transform.position.y, shootMe.transform.position.z));

        // If has the enemy on sight (look from center of body), shoot..
        if (Physics.Raycast(new Vector3(agent.transform.position.x, agent.height / 2, agent.transform.position.z),
        (shootMe.transform.position - agent.transform.position).normalized, out hit)
            && hit.collider.tag == enemyTag)
        {
            if (hit.collider.name == "Body" && hit.collider.tag == enemyTag)
            {
                BodyHit bh = hit.collider.GetComponent<BodyHit>();
                bh.setDmg(dmg);
            }

            animator.SetInteger("NPCmode", 0);
            agent.velocity = Vector3.zero; // Stop agent speed
            if (!isShooting)
            {
                StartCoroutine(ShowFlash());
                StartCoroutine(simulateShoot(shootMe));
            }
        }
        else // Does not have the enemy on sight but still close to him, update destination and walk.
        {
            animator.SetInteger("NPCmode", 1);
            agent.SetDestination(shootMe.transform.position);
        }
    }

    NavMeshAgent GetClosestAgent(NavMeshAgent[] enemies)
    {
        NavMeshAgent bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (NavMeshAgent potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
    IEnumerator simulateShoot(NavMeshAgent shootMe)
    {

        isShooting = true;
        int hitChance = Random.Range(0, 100);
        if (agent.enabled)
        {
            animator.SetInteger("NPCmode", 2);
            shootSound.Play();
            if (hitChance >= successRate)
            {
                bullet.SetActive(true);
                bullet.transform.position = shootMe.transform.position;
            }
            // else missed
        }
        yield return new WaitForSeconds(shootRate);
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
