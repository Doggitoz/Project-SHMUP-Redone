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

public class MaterialScroller : MonoBehaviour
{

    /*** VARIABLES ***/

    public Vector2 scrollSpeed = new Vector2(0, 0f);

    private Renderer goRenderer;
    private Material goMat;

    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (scrollSpeed * Time.deltaTime);
        goMat.mainTextureOffset += offset;
    }
}
