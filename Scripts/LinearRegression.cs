using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LinearRegression : MonoBehaviour {

    [SerializeField]
    private GameObject[] spheres;

    [SerializeField]
    private GameObject[] gameObject;

    [DllImport("machine_learning")]
    private static extern double regress_point(System.IntPtr weights, double[] point);

    [DllImport("machine_learning")]
    private static extern System.IntPtr linear_regression(double[] raw_points,
                                                            double[] raw_results,
                                                            long dim,
                                                            long nb_elements
                                                            );

    // Use this for initialization
    void Start () {
        List<double> dataList = new List<double>();
        List<double> resultList = new List<double>();

        foreach (var sphere in spheres) {
            dataList.Add(sphere.transform.localPosition.x);
            dataList.Add(sphere.transform.localPosition.y);
            dataList.Add(sphere.transform.localPosition.z);

            resultList.Add(sphere.transform.localPosition.y);
        }

        System.IntPtr weights = linear_regression(dataList.ToArray(), resultList.ToArray(), 3L, (long) resultList.ToArray().Length);
        
        for (var i = 0; i < gameObject.Length; i++)
        {
            var tmp = new double[3];
            Marshal.Copy(weights, tmp, 0, 3);
            
            List<double> l = new List<double>();
            l.Add(gameObject[i].transform.localPosition.x);
            l.Add(gameObject[i].transform.localPosition.z);
            Debug.Log(tmp[0] + " / " + tmp[1] + "/" + tmp[2]);
            gameObject[i].transform.position += Vector3.up * (float)regress_point(weights, l.ToArray());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
