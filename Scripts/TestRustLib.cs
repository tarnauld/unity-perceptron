using System;
using UnityEngine;
using System.Runtime.InteropServices;

public class TestRustLib : MonoBehaviour {
	[DllImport("liblinear_learning")]
	private static extern Int32 add_numbers(Int32 number1, Int32 number2);

	[SerializeField] private Transform[] transforms;

	// Use this for initialization
	void Start () {
		Debug.Log(add_numbers(12, 14));
		/*transforms[0].position += Vector3.right * 2f;
		transforms[1].position += Vector3.left * 2f;
		transforms[2].position += Vector3.up * 2f;*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
