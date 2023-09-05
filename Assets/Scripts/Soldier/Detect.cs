using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Detect : MonoBehaviour
{
	private bool playerDetected = false;
	public  bool SoldierAttack = false;

	public NavMeshAgent agent;
	public float range=10f; //radius of sphere


	private float distanceBetweenPlayer=100f;
	public float DetectDistance = 15f;
	public float AttackDistance = 5f;

	public float Soldierspeed = 1f;
	private float step;
	private bool isThereAWall = false;

	public float RandomAvoidWall = 4f;


	public Transform PlayerTransform;
	public Animator SoldierAnim;

	private void Start()
	{
	}
	private void Update()
	{
		distanceBetweenPlayer = Vector3.Distance(transform.position, PlayerTransform.position);


		if (distanceBetweenPlayer<= DetectDistance)
		{

			
				playerDetected = true;
				SoldierAnim.SetBool("run", true);

				Vector3 targetPosition = new Vector3(PlayerTransform.position.x, transform.position.y, PlayerTransform.position.z);
				transform.rotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

				if (distanceBetweenPlayer <= AttackDistance)
				{
					SoldierAttack = true;
					SoldierAnim.SetBool("run", false);

				}
				else
				{
					SoldierAttack = false;
					step = Soldierspeed * Time.deltaTime;
					agent.SetDestination(PlayerTransform.transform.position);
				}
			

			

		}
		else
		{
			playerDetected = false;
			SoldierAnim.SetBool("run", false);

		}
	}
	/*
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			isThereAWall = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			isThereAWall = false;
		}
	}
	*/
	/*bool RandomPoint(Vector3 center, float range, out Vector3 result)
	{

		Vector3 randomPoint = center + Random.insideUnitSphere * range;
		NavMeshHit hit;
		if (NavMesh.SamplePosition(randomPoint, out hit, 0.5f, NavMesh.AllAreas)) 
		{
			//the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
			//or add a for loop like in the documentation
			result = hit.position;
			return true;
		}

		result = Vector3.zero;
		return false;
	}
	*/



}
