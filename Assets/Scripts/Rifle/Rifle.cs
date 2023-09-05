using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rifle : MonoBehaviour
{
    public float rifleCheckDistance=2.4f;
    public TextMeshProUGUI pressE;
    
    public Animator leftArm;
    public Animator rightArm;

    public Transform Player;
    public GameObject cross;
    public float Radius = 2f;

    public GameObject rifle;
    public GameObject floorRifle;
    public AudioSource rifleTakeSound;


    private float PLayerDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PLayerDistance =Vector3.Distance( Player.position ,transform.position);
		if (PLayerDistance<= rifleCheckDistance)
		{
            Debug.Log("hjkl");
            pressE.enabled = true;
			if (Input.GetKey(KeyCode.E))
			{
                cross.SetActive(true);
                leftArm.SetBool("armed", true);
                rightArm.SetBool("armed", true);
                rifleTakeSound.enabled = true;
                pressE.enabled = false;
                rifle.SetActive(true);
                floorRifle.SetActive(false);

                
			}

		}
		else
		{
            rifleTakeSound.enabled = false;

            pressE.enabled = false;
		}




    }



}
