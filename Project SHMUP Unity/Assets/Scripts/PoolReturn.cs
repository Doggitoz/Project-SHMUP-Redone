/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: Coleton Wheeler
 * Last Edited: April 13, 2022
 * 
 * Description: Object Pooling Return
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL;
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.ReturnObject(this.gameObject);
        }
    }
}
