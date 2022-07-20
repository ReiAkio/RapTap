using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public float respawnTime;

    private void Start()
    {
        StartCoroutine(noteWave());
    }

    public void Spawn()
    {
        Instantiate(objectToSpawn, new Vector3((Random.Range(1,4)) * Screen.width/4, Screen.height, 0), Quaternion.identity, parent.transform);
    }

    IEnumerator noteWave()
    {
        while (objectToSpawn.activeSelf == true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }
}
    