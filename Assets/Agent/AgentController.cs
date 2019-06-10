using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentController : MonoBehaviour
{
	GameController gc = GameController.instance;

    [SerializeField]
	private int moveSpeed = 1;
    [SerializeField]
	private int neighbourhoodDistance = 10;
	
	void Update()
	{
		Quaternion wanderRot = Wander(transform.rotation);

		Transform finalTransform = transform;
		finalTransform.rotation = wanderRot;

		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		transform.rotation = finalTransform.rotation;

        if (gc.debugging)
		    foreach (GameObject a in GetNeighbours())
		        Debug.DrawLine(transform.position, a.transform.position, Color.red);
	}

    // used for wandering
	Quaternion GetNewRot()
	{
		return Quaternion.Euler
		(
			Random.Range(0, 360),
			Random.Range(0, 360),
			Random.Range(0, 360)
		);
	}

	Quaternion Wander(Quaternion q)
	{
		q = Quaternion.RotateTowards(q, GetNewRot(), 10.0f);
		return q;
	}

	IEnumerable<GameObject> GetNeighbours()
	{
		return gc.agents.Where(a => Vector3.Distance(a.transform.position, transform.position) <= neighbourhoodDistance);
	}
}
