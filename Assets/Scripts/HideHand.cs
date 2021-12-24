using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHand : MonoBehaviour
{
	public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player")
		{
			hand.SetActive(false);
		}
	}
	
	void OnTriggerExit(Collider collider){
		if(collider.tag == "Player")
		{
			hand.SetActive(true);
		}
	}
}
