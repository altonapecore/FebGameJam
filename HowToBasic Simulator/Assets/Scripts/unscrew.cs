using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unscrew : MonoBehaviour
{
	public unscrew[] screwGroup;
	Rigidbody toRelease;
	public Vector3 unscrewTarget;
	public bool unscrewed = false;
	Vector3 unscrewStart;
	float unscrewLerp = 0;
	bool lerping = false;

	private void Start()
	{
		unscrewStart = transform.localPosition;
		toRelease = transform.parent.GetComponent<Rigidbody>();
	}

	private void OnMouseDown()
	{
		if (!unscrewed)
			lerping = true;
	}

	private void OnMouseUp()
	{
		lerping = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (lerping)
		{
			transform.localPosition = Vector3.Lerp(unscrewStart, transform.rotation * unscrewTarget + unscrewStart, unscrewLerp);
			unscrewLerp += .02f;
		}

		if (unscrewLerp >= .9 && !unscrewed)
		{
			GetComponent<Rigidbody>().isKinematic = false;
			unscrewed = true;
			lerping = false;
			transform.SetParent(null, true);
			bool allUnscrewed = true;
			foreach(unscrew screw in screwGroup)
			{
				if (!screw.unscrewed)
				{
					allUnscrewed = false;
				}
			}
			if (allUnscrewed)
			{
				toRelease.isKinematic = false;
				toRelease.WakeUp();
			}
		}
	}
}
