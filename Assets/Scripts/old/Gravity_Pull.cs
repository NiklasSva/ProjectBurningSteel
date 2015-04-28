using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity_Pull : MonoBehaviour {
	
	//Declare Variables:
	
	//Strength of attraction from your sphere (obviously, it can be any type of game-object)
	public float StrengthOfAttraction;
	
	List<GameObject> roads = new List<GameObject>();
	GameObject m_closestGO;
	
	//Initialise code:
	void Start () 
	{
		roads = new List<GameObject>(GameObject.FindGameObjectsWithTag("Road"));
	}
	
	//Use FixedUpdate because we are controlling the orbit with physics
	void FixedUpdate () 
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();

		//magsqr will be the offset squared between the object and the planet
		float magsqr;
		
		//offset is the distance to the planet
		Vector3 offset;
		float shortest_distance = 0.0f;
		for(int i = 0; i < roads.Count; i++)
		{
			float dist = Vector3.Distance(transform.position, roads[i].transform.position);
			if(dist < shortest_distance || shortest_distance <= 0.0001f)
			{
				shortest_distance = dist;
				m_closestGO = roads[i];
			}
		}

		Vector3 new_grav = m_closestGO.transform.forward * -1;
		offset = m_closestGO.transform.position - transform.position;
		magsqr = offset.sqrMagnitude;

		rigidbody.AddRelativeForce(new_grav);
		Debug.DrawLine(m_closestGO.transform.position, m_closestGO.transform.up * (7), Color.red);

		Vector3 up = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, up * (-1), 1))
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z);
			//rigidbody.AddRelativeForce(0.0f, 0.1f, 0.0f);
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
		}
			/*
		for(int i = 0; i < roads.Count; i++)
		{
			//get offset between each planet and the player
			offset = roads[i].transform.position - transform.position;
			
			//Offset Squared:
			magsqr = offset.sqrMagnitude;
			
			//Check distance is more than 0 to prevent division by 0
			if (magsqr > 0.0001f)
			{
				//Create the gravity- make it realistic through division by the "magsqr" variable
				rigidbody.AddForce((StrengthOfAttraction * offset.normalized / magsqr) * rigidbody.mass);
			}
		}
		*/
	}
}