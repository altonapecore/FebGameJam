using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysGrab : MonoBehaviour
{
	public Rigidbody anchor;
	Rigidbody thisRB;
	bool grabbed;
	SpringJoint spring;
	private void Start()
	{
		thisRB = GetComponent<Rigidbody>();
		spring = anchor.GetComponent<SpringJoint>();
		anchor.transform.SetParent(null, true);
	}

	private void OnMouseDown()
	{
		if (!thisRB.isKinematic)
		{
			grabbed = true;
			spring.connectedBody = thisRB;
			anchor.transform.position = transform.position;
			spring.connectedAnchor = new Vector3(0,0,0);
			spring.anchor = transform.position;
		}
		
	}

	private void OnMouseUp()
	{
		grabbed = false;
		spring.connectedBody = null;
	}

	// Update is called once per frame
	void Update()
	{
		if (grabbed)
		{
			anchor.transform.position = new Vector3(anchor.transform.position.x, 2, anchor.transform.position.z);
			anchor.transform.position += new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
			thisRB.WakeUp();
		}
	}
}
