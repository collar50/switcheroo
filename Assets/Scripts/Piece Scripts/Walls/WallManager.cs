using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
	[SerializeField] private float currentTypeDuration;
	[SerializeField] private Color[] color = new Color [4];



	[SerializeField] private int wallId;

	private SpriteRenderer spriteRenderer;

	void Start ()
	{		
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		ChangeWallID ();


		// This will be the smallest multiple of the currentTypeDuration that is greater than the timeSinceLevelLoad. It's when, in
		// scene time, the next WallID change should occur. 
		float nextTimeToChange = ((int)Time.timeSinceLevelLoad / (int)currentTypeDuration + 1) * currentTypeDuration;

		// Calibrate the time for the next change to account for when this wall was instantiated
		float timeToChangeSinceThisCreated = nextTimeToChange - Time.timeSinceLevelLoad;

		InvokeRepeating ("ChangeWallID", timeToChangeSinceThisCreated, currentTypeDuration);
	}

	private void ChangeWallID ()
	{
		int rand = Random.Range (0, 4);
		wallId = rand;
		spriteRenderer.color = color [rand];
	}

	public int WallID { get { return wallId; } }
}
