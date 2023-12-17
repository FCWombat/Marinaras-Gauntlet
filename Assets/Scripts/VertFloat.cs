using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VertFloat : MonoBehaviour
{
	public float startingY;
	public float startingX;
	public float speed;
	public float topY;
	public float bottomY;

	// Start is called before the first frame update
	void Start()
    {
		transform.SetPositionAndRotation(new Vector3(startingX, startingY, -0.5f), new Quaternion());
    }

	// Update is called once per frame
	void Update()
	{
		transform.SetPositionAndRotation( new Vector3(startingX,					
			((((topY - bottomY) / 2) * Mathf.Sin(speed * Time.time)) + (topY/2) + (bottomY/2)),
			-0.5f), new Quaternion());
	}
}
