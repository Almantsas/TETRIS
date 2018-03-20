using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] figures;

    public void SpawnFigure()
    {
        int i = Random.Range(0, figures.Length);
        Instantiate(figures[i], transform.position, Quaternion.identity);
    }


	// Use this for initialization
	void Start () {
        SpawnFigure();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
