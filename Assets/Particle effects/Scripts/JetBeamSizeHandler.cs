using UnityEngine;
using System.Collections;

public class JetBeamSizeHandler : MonoBehaviour {

	public ParticleSystem m_ParticleSystem;
	public float m_StartSize;
	public float m_StartLifetime;

	// Use this for initialization
	void Start () 
	{

		m_StartSize = 50;
		m_StartLifetime = 0.1f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("space")) 
		{

			m_StartSize = 100;
			m_StartLifetime = 0.5f;


		} 
		else 
		{

			m_StartSize = 50;
			m_StartLifetime = 0.1f;

		}
		m_ParticleSystem.startSize = m_StartSize;
		m_ParticleSystem.startLifetime = m_StartLifetime;
	}
}
