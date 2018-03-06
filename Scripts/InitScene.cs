using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class InitScene : MonoBehaviour
{
	private List<GameObject> _gameObjects = new List<GameObject>();

	[SerializeField]
	private GameObject sphereBlue;
	
	[SerializeField]
	private GameObject sphereRed;
	
	[SerializeField]
	private GameObject sphereWhite;
	
	// Use this for initialization
	void Start () {

		for (var i = -10; i < 10; i++)
		{
			for (var j = -10; j < 10; j++)
			{
				Instantiate(sphereWhite, new Vector3(i, j), Quaternion.identity);
			}	
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
