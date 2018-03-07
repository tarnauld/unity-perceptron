using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LinearClassification : MonoBehaviour {
	[DllImport("linear_learning")]
	private static extern float[] linear_classification(float step, float[] p, int nb);

	[SerializeField] private GameObject sphere1, sphere2, sphere3;

	// Use this for initialization
	void Start ()
	{
		List<float> list = new List<float>();
		list.Add(sphere1.transform.localPosition.x);
		list.Add(sphere1.transform.localPosition.y);
		list.Add(sphere1.transform.localPosition.z);
		list.Add(sphere2.transform.localPosition.x);
		list.Add(sphere2.transform.localPosition.y);
		list.Add(sphere2.transform.localPosition.z);
		list.Add(sphere3.transform.localPosition.x);
		list.Add(sphere3.transform.localPosition.y);
		list.Add(sphere3.transform.localPosition.z);
		//float[] res = linear_classification(0.1f, list.ToArray(), 5);
		//Debug.Log(res[0] + ": " + res[1] + ": " + res[2]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
