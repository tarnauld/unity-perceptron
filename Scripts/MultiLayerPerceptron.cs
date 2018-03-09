using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MultiLayerPerceptron : MonoBehaviour {
	[DllImport("mutlilayer_perceptron")]
	private static extern System.IntPtr create_model(int[] d, int length);
	
	[DllImport("mutlilayer_perceptron")]
	private static extern void train_weights(System.IntPtr ptr,int nb, double[] pts, int l);
	
	[DllImport("mutlilayer_perceptron")]
	private static extern double classification(System.IntPtr ptr, double[] t);

	[SerializeField]
	private GameObject[] spheres;

	[SerializeField] private GameObject[] gameObjects;
	
	
	void Start ()
	{
		var d = new List<int> {2, 3, 3, 3, 1};

		var ptr = create_model(d.ToArray(), d.Count);

		var list = new List<double>();

		foreach (var sphere in spheres){
			list.Add(sphere.transform.position.x / 10.0);
			list.Add(sphere.transform.position.y / 2.0);
			list.Add(sphere.transform.position.z / 5.0);
		}

		train_weights(ptr, 10000, list.ToArray(), list.Count);

		foreach (var go in gameObjects)
		{
			var tmp = new List<double> {go.transform.localPosition.x / 10.0, go.transform.localPosition.z / 5.0};
			Debug.Log("x: " + go.transform.localPosition.x + "-> z: " + go.transform.localPosition.z + " -> y: " + (float)classification(ptr, tmp.ToArray()));
			go.transform.position += Vector3.up * (float)classification(ptr, tmp.ToArray());
		}
		
		Marshal.FreeHGlobal(ptr);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
