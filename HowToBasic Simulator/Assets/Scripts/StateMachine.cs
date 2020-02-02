using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public int state = -1;
	public Transform spawnTarget;

	public GameObject[] spawns;

	public Rigidbody phoneLogicBoard;
	public HandHandler thumbsUp;
	public UnityEngine.UI.Button nextButton;

	private void Start()
	{
		nextButton.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update()
	{
		if (state < 0)
		{
			if (!phoneLogicBoard.isKinematic)
			{
				Happenb(); // Fuck everything about event driven programming do ifs in update now
				nextButton.gameObject.SetActive(true);
			}
		}
	}

	public void Happenb()
	{
		state++;
		if (state == spawns.Length)
		{
			thumbsUp.ThumbsUp();
			StartCoroutine(WaitForQuit());
			return;
		}
		else if (state < spawns.Length)
		{
			Instantiate(spawns[state], spawnTarget);
		}
	}

	IEnumerator WaitForQuit()
	{
		yield return new WaitForSeconds(4);
		Application.Quit(); //lmao
	}
}
