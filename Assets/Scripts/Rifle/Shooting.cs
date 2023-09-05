using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public CameraShake cameraShake;


    public float damage = 10f;
    public float range = 100f;
    public float force = 30f;
    public float Magnitude = 0.4f;

    public AudioSource gunShot;

    public ParticleSystem muzzleFlash;

    public Animator animator;
    public GameObject sandImpact;
    public GameObject ScopeImage;
    public Camera MainCamera;

    private float mainFOV;
    public float ZoomedFOV=50f;



    public Camera fpsCam;
	// Update is called once per frame
	private void Start()
	{
	}
	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("scope", true);
            StartCoroutine(OnScope());

        }
        else if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("scope", false);
            UnScope();
        }

    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        gunShot.Play();
        StartCoroutine(cameraShake.Shake(.15f, Magnitude));
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
            Debug.Log(hit.transform.name);
			
			
            Enemy enemy = hit.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
                enemy.Damage(damage);
            }
			if (hit.rigidbody != null)
			{
                hit.rigidbody.AddForce(-hit.normal * force);
			}
        
            GameObject impactGO = Instantiate(sandImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
		}

    }
    void UnScope()
	{
        ScopeImage.SetActive(false);
        MainCamera.fieldOfView = 60f;
	}
    IEnumerator OnScope()
	{
        yield return new WaitForSeconds(0.15f);
        ScopeImage.SetActive(true);

        mainFOV = MainCamera.fieldOfView;
        MainCamera.fieldOfView = ZoomedFOV;
	}
}
