using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Headshot : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.transform.parent.GetComponent<Animator>();
        agent = transform.parent.transform.parent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hit" || other.tag == "EnemyHit")
        {
            other.gameObject.SetActive(false);
            simDeath();
        }
    }

    private void simDeath()
    {
        // NPC Death
        animator.SetInteger("NPCmode", 5);
        agent.enabled = false;
        // Disable Colliders
        foreach (Collider c in this.transform.parent.GetComponentsInChildren<Collider>())
        {
            if (c.isTrigger)
                c.enabled = false;
        }
        // Disable sounds
        foreach (AudioSource ac in this.transform.root.GetComponentsInChildren<AudioSource>())
        {
            ac.enabled = false;
        }
    }
}
