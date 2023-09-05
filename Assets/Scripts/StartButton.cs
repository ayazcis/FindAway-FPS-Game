using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public AudioSource click;
	public void Button()
	{
		StartCoroutine(buttonclick());
	}
	IEnumerator buttonclick()
	{
		click.Play();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(1);
	}
}
