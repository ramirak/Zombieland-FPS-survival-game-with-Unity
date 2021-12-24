using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem : MonoBehaviour
{
    private Animator animator;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.gameObject != null && hit.distance < 5 && this.transform.gameObject == hit.transform.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    animator.SetBool("open", !animator.GetBool("open"));
                }
            }
        }
    }
}
