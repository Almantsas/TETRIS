using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] figures;
    public GameObject[] nextFigures;
    int index;
    int nextIndex;

    public void SpawnFigure()
    {
        index = nextIndex;
        Instantiate(figures[index], transform.position, Quaternion.identity);

        if (nextFigures[nextIndex].activeSelf)
        {
            nextFigures[nextIndex].SetActive(false);
        }

        nextIndex = Random.Range(0, nextFigures.Length);
        nextFigures[nextIndex].SetActive(true);
        
    }

	// Use this for initialization
	void Start () {
        nextIndex = Random.Range(0, nextFigures.Length);
        SpawnFigure();
	}
}
