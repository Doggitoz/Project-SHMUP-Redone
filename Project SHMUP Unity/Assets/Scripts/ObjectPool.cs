/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: Coleton Wheeler
 * Last Edited: April 13, 2022
 * 
 * Description: Object Pooling
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    /* VARIABLES */
    static public ObjectPool POOL;
    private Queue<GameObject> projectiles = new Queue<GameObject>();

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    #region Pool Singleton
    void CheckPOOLIsInScene()
    {
        if (POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.LogError("POOL.Awake() - Attempeeted to assign second ObjectPool.POOL");
        }
    }

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        CheckPOOLIsInScene();
    }

    private void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectileGO.transform.SetParent(transform);
            projectiles.Enqueue(projectileGO);
            projectileGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObject()
    {
        if (projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of objects, reloading...");
            return null;
        }
    }

    public void ReturnObject(GameObject gObject)
    {
        projectiles.Enqueue(gObject);
        gObject.SetActive(false);
    }
}
