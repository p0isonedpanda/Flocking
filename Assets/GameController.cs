using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance { get; private set; }

    public bool debugging = false;
	[HideInInspector] public List<GameObject> agents;
	[SerializeField] private GameObject agent;

	void Awake()
	{
		if (instance != null)
		    throw new System.Exception();
		
		instance = this;
	}

	void Start ()
	{
		agents = new List<GameObject>();

		for (int i = 0; i < 500; i++)
		{
			Vector3 pos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
			Quaternion rot = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
			agents.Add(Instantiate(agent, pos, rot));
		}
	}
}
