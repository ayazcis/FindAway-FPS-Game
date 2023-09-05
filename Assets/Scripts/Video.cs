using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(videoended());
    }

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene(2);

		}
	}

	IEnumerator videoended()
	{
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene(2);
	}
}
