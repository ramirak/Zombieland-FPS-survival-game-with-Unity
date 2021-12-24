using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject npc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Animator animator = npc.GetComponent<Animator>();
        if (other.tag == npc.tag)
        {
            if (animator.GetInteger("NPCmode") == 1)
                animator.SetInteger("NPCmode", 3);
            else if (animator.GetInteger("NPCmode") == 3)
                animator.SetInteger("NPCmode", 1);
        }
    }
}
