using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLand : MonoBehaviour
{
    private AudioSource horror;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        horror = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            // Activate tense music
            horror.Play();
            // Start zombie propagation (Disabled for performance)
            zombie.active = true;
        }
    }
}
