using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LinearClassification : MonoBehaviour {

    [DllImport("machine_learning")]
    private static extern System.IntPtr generate_weight();

    [DllImport("machine_learning")]
    private static extern System.IntPtr weights_training(System.IntPtr ptr, double[] data_set, long nb_points);

    [DllImport("machine_learning")]
    private static extern double classify(double   [] row, double[] ptr);

    [SerializeField]
    private GameObject[] spheres;

    [SerializeField] private GameObject[] gameObject;

	// Use this for initialization
	void Start ()
	{
        Debug.Log(classify( new[] {1.0d, 1.0d }, new[] { 1.0d, 1.0d, 1.0d }));
        Debug.Log(classify(new[] { -1.0d, -1.0d }, new[] { 1.0d, 1.0d, 1.0d }));
        Debug.Log(classify(new[] { 1.0d, -1.0d }, new[] { 1.0d, 1.0d, 1.0d }));

        Debug.Log(classify(new[] { 1.0d, 1.001d }, new[] { 0.0d, -1.0d, 1.0d }));
        Debug.Log(classify(new[] { 1.0d, 0.999d }, new[] { 0.0d, -1.0d, 1.0d }));
        Debug.Log(classify(new[] { 0.0d, -1.0d }, new[] { 0.0d, -1.0d, 1.0d }));

        Debug.Log(classify(new[] { 1.0d, 1.0d }, new[] { -0.5d, 1.0d, 0.0d }));
        Debug.Log(classify(new[] { -1.0d, -1.0d }, new[] { -0.5d, 1.0d, 0.0d }));
        Debug.Log(classify(new[] { -1.0d, 1.0d }, new[] { -0.5d, 1.0d, 0.0d }));


        System.IntPtr ptr = generate_weight();
        var tmp = new double[3];
        Marshal.Copy(ptr, tmp, 0, 3);
        List<double> l2 = new List<double>();

        foreach(var t in tmp)
        {
            Debug.Log(t);
        }


        List<double> list = new List<double>();

        foreach (var sphere in spheres)
        {
            list.Add(sphere.transform.localPosition.x);
            list.Add(sphere.transform.localPosition.y);
            list.Add(sphere.transform.localPosition.z);
        }
        
        //System.IntPtr ptr = generate_weight();
        ptr = weights_training(ptr, list.ToArray(), list.ToArray().Length);
        
        for (var i = 0; i < gameObject.Length; i++)
        {
            //var tmp = new double[3];
            Marshal.Copy(ptr, tmp, 0, 3);
            List<double> l = new List<double>();
            l.Add(gameObject[i].transform.localPosition.x);
            l.Add(gameObject[i].transform.localPosition.z);
            if (classify(l.ToArray(), tmp) > 0)
            {
                gameObject[i].transform.position += Vector3.up;
            }
            else
            {
                gameObject[i].transform.position += Vector3.down;
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
