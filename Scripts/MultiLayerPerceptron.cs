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

	//[SerializeField] private GameObject[] gameObjects;
	
	
	void Start ()
	{
		var d = new List<int> {2, 3, 1};

		var ptr = create_model(d.ToArray(), d.Count);

		var list = new List<double>();

		foreach (var sphere in spheres){
			list.Add(sphere.transform.position.x);
			list.Add(sphere.transform.position.y);
			list.Add(sphere.transform.position.z);
		}

		train_weights(ptr, 12, list.ToArray(), list.Count);
		
		foreach (var sphere in spheres)
		{
			var tmp = new List<double> {sphere.transform.localPosition.x, sphere.transform.localPosition.z};
			Debug.Log("x: " + sphere.transform.localPosition.x + "-> z: " + sphere.transform.localPosition.z + " -> y: " + (float)classification(ptr, tmp.ToArray()));
		}

		/*foreach (var go in gameObjects)
		{
			var tmp = new List<double> {go.transform.localPosition.x, go.transform.localPosition.z};
			Debug.Log("x: " + go.transform.localPosition.x + "-> z: " + go.transform.localPosition.z + " -> y: " + (float)classification(ptr, tmp.ToArray()));
			go.transform.position += Vector3.up * (float)classification(ptr, tmp.ToArray());
		}*/
		
		Marshal.FreeHGlobal(ptr);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
