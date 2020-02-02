using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unscrew : MonoBehaviour
{
	public unscrew[] screwGroup;
	public GameObject screwDriver;
	public GameObject phone;
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
		{
			screwDriver.transform.position = transform.position;
			if (transform.rotation.z == 0)
			{
				screwDriver.transform.rotation = Quaternion.Euler(0, phone.transform.rotation.y + 90.0f, 90.0f);
			}
			else
			{
				screwDriver.transform.rotation = Quaternion.Euler(0, 0, 180.0f);
			}
			lerping = true;
			this.GetComponent<AudioSource>().Play();
		}
		
	}

	private void OnMouseUp()
	{
		lerping = false;
		this.GetComponent<AudioSource>().Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (lerping)
		{
			transform.localPosition = Vector3.Lerp(unscrewStart, transform.rotation * unscrewTarget + unscrewStart, unscrewLerp);
			unscrewLerp += .02f;
			screwDriver.transform.position = transform.position;
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
