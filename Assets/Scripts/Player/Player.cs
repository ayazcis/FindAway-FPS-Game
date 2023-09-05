using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float health = 60f;
	[SerializeField]
	public Image HurtRed;
	private float alpha;


	private void Start()
	{
	}

	private void Update()
	{
		if (HurtRed.color.a > 0)
		{
			alpha = HurtRed.color.a;
			alpha -= 0.1f;
			HurtRed.color = new Color(HurtRed.color.r, HurtRed.color.g, HurtRed.color.b, alpha);
		}
	}

	public void Damage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		SceneManager.LoadScene(2);

	}
}
