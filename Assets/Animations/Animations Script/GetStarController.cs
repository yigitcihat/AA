using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStarController : MonoBehaviour
{

	// explosion when hit?
	public GameObject starexplosionPrefab;
	public int scoreAmount = 0;

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Ball")
		{
			if (starexplosionPrefab)
			{
				Instantiate(starexplosionPrefab, transform.position, transform.rotation);
			}

			// destroy self
			Destroy(gameObject);
		}
	}
    

}
