using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] spawnTemplates;
    public Transform emptySpawn;

    // Start is called before the first frame update
    void Start()
    {   
        //RandomSpawn(); 
        //SpawnFromList();
        //SpawnFinite();
        //SpawnInfinite();
    }

    void Update() 
    {
        //SpawnWithSpace();
    }


    void SpawnWithSpace() {
        if (Input.GetButtonDown("Jump")) {
            RandomSpawn();
        }
    }

    void SpawnFromList() {
        StartCoroutine(ForEachSpawn());       
    }

    void SpawnFinite() {
        StartCoroutine(ForSpawn());
    }

    void SpawnInfinite() {
        StartCoroutine(WhileSpawn());
    }


    // For loop example: do a limited number of loops (10 in this case)
    IEnumerator ForSpawn() {
        for (int i = 0; i < 10; i++) {
            RandomSpawn();
            yield return new WaitForSeconds(.7f);
        }
    }

    // For Each loop example: loop over all prefabs in spawnTemplates and spawn each prefab
    IEnumerator ForEachSpawn() {
        foreach (GameObject obj in spawnTemplates) {
            SpawnSpecificPrefab(obj);
            yield return new WaitForSeconds(.7f);
        }
    }

    // While loop: keep looping while the condition is true (in this case, always true since the condition itself is true)
    // TODO: change the loop so that it loops only a certain number of time
    IEnumerator WhileSpawn() {
        while (true) {
            RandomSpawn();
            yield return new WaitForSeconds(.7f);           
        }
    }


    // Randomly spawn a cube from the list of prefabs (contains OOP example)
    void RandomSpawn() {
        int prefabIdx = Random.Range(0, spawnTemplates.Length);
        
        float xPos = Random.Range(-3.5f, 3.5f);
        float yPos = 7f;
        float zPos = Random.Range(-3.5f, 3.5f);

        Vector3 pos = new Vector3(xPos, yPos, zPos);
        
        GameObject spawn = Instantiate(spawnTemplates[prefabIdx], pos, emptySpawn.rotation);
        
        Debug.Log(spawn.tag);  // spawn.tag accesses the tag field of the GameObject spawn
        spawn.AddComponent<CollisionDetector>(); // add the CollisionDetector component to the GameObject spawn
        
    }

    void SpawnSpecificPrefab(GameObject prefab) {
        float xPos = Random.Range(-3.5f, 3.5f);
        float yPos = 7f;
        float zPos = Random.Range(-3.5f, 3.5f);

        Vector3 pos = new Vector3(xPos, yPos, zPos);
        GameObject spawn = Instantiate(prefab, pos, emptySpawn.rotation);
        spawn.AddComponent<CollisionDetector>();
    }
}

