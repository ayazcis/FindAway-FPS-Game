using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierShooting : MonoBehaviour
{
    public Detect detect;

	public AudioSource GunShot;
	public float damage = 10f;


	public CameraShake cameraShake;

	public Transform SoldierGunTransform;
	public float range = 100f;
	public ParticleSystem muzzleFlash;

	public Player player;
	public float Magnitude=0.4f;
	
	public int ShotPossibility = 2;
	public float force = 30f;
	public Image HurtRed;
	private float alpha = 0;

	private float lastShot = 0f;
	private int shoot = 0;
	public float MaxTimeBetweenShots = 3f;
	public float MinTimeBetweenShots = 3f;
	private float timeBetweenShots = 1f;
	private void Start()
	{
		lastShot = Time.time;
	}
	private void Update()
	{

		if (detect.SoldierAttack)
		{
		
			timeBetweenShots= Random.Range(MinTimeBetweenShots, MaxTimeBetweenShots);
			if (Time.time - lastShot >= timeBetweenShots)
			{
				shoot = Random.Range(1, ShotPossibility);

				lastShot = Time.time;

				GunShot.Play();
				muzzleFlash.Play();
				Debug.Log(shoot);
				if (shoot == 1)
				{
					alpha = 0.8f;
					HurtRed.color = new Color(HurtRed.color.r, HurtRed.color.g, HurtRed.color.b, 0.8f); 

					StartCoroutine(cameraShake.Shake(.15f, Magnitude));

					player.Damage(damage);

						
						

						//GameObject impactGO = Instantiate(sandImpact, hit.point, Quaternion.LookRotation(hit.normal));
						//Destroy(impactGO, 2f);
				}

				}
			}

		}
	
	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(SoldierGunTransform.position,-Vector3.forward);
		Gizmos.DrawRay(transform.position, -Vector3.forward);

	}



}
