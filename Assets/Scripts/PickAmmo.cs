using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    //   public AudioSource pickAmmo;
    //  public Text ammoCount;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
    }
    // Update is called once per frame    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //         this.gameObject.SetActive(false);
            //       pickAmmo.Play();
            //     ammoCount.text = "blabla";
        }
    }

}
