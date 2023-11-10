using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public static Spawner Instance { get; private set; }
    public GameObject BluePlane;
    public GameObject RedPlane;

    public GameObject GreenPlane;


    private Vector3 TowerPos;


    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
    }

   
    public void setTowerPosition(Vector3 towerPos) {

        TowerPos = towerPos; 
    }

    public void spawnPlane(GameObject Plane)
    {
        GameObject spawnPoint = new GameObject();

        float height = Random.Range(0.5f,1.5f); 
        float Depth = Random.Range(0.5f, 1.5f);

        Vector3 PlaneSpawnPoint = new Vector3(0.0f, this.TowerPos.y+height, TowerPos.z+Depth);

        spawnPoint.transform.position = PlaneSpawnPoint;


        Instantiate(Plane, spawnPoint.transform);
    }

    public void spawnblueplane()
    {
        spawnPlane(BluePlane);

            }
    public void spawnRedplane()
    {
        spawnPlane(RedPlane);
    }

    public void spawnGreenplane()
    {
        spawnPlane(GreenPlane);
    }

    public void spawnRedPlaneAfterTime(float time)
    {
        Invoke("SpawnRedplane", time);
    }
    public void spawnGreenPlaneAfterTime(float time)
    {
        Invoke("SpawnRedplane", time);
    }
    public void spawnBluePlaneAfterTime(float time)
    {
        Invoke("SpawnBlueplane", time);
    }
}
