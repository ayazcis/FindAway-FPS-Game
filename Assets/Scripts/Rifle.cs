using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rifle : MonoBehaviour
{
    public float rifleCheckDistance=2.4f;
    public TextMeshProUGUI pressE;
    public LayerMask whatIsPlayer;

    public GameObject rifle;
    public GameObject floorRifle;
    public AudioSource rifleTakeSound;

    private bool checkPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayer = CheckPlayer();
		if (checkPlayer)
		{
            pressE.enabled = true;
			if (Input.GetKey(KeyCode.E))
			{
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
    public virtual bool CheckPlayer()
	{
        return Physics.Raycast(transform.position, transform.right, rifleCheckDistance, whatIsPlayer);
	}
	private void OnDrawGizmos()
	{
        Gizmos.DrawLine(transform.position, transform.position + transform.right * rifleCheckDistance);
	}
}
