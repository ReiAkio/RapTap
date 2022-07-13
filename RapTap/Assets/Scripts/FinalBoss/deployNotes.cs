using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class deployNotes : MonoBehaviour
{
    public GameObject notePrefab;
    public float respawnTime = 1.0f;
    private Vector2 _screenBounds;
    
    void Start()
    {
        if (Camera.main != null) 
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(noteWave());
    }

    private void spawnEnemy()
    {
        GameObject n = Instantiate(notePrefab) as GameObject;
        n.transform.position = new Vector2(Random.Range(-_screenBounds.x, _screenBounds.x), _screenBounds.y * 2);
    }

    IEnumerator noteWave()
    {
        while (notePrefab.activeSelf == true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
