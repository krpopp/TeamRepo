using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //this is my comment actually
    //here's another comments
    //ahhhh
    //this is also a change! cool! cool change!


    //Hey What's up!? This is my change! Hopefully you can see it when I push!! :)
    public Transform followTransform;
    public BoxCollider2D worldBounds;
    float xMin, xMax, yMin, yMax;
    float camY, camX;

    //holds the size of our vertical size of our camera
    float camSize;
    //holds the horizontal size of our camera
    float camRatio;

    Camera mainCam;
    //staggered "smooth" position
    Vector3 smoothPos;
    //how quickly we should follow the player
    public float smoothRate;

    // Start is called before the first frame update
    void Start()
    {
        xMin = worldBounds.bounds.min.x;
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;
        mainCam = gameObject.GetComponent<Camera>();
        
        //find our sizes and do some math to related them 
        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        //clamp means we're limited our camera to an area
        //offset them by half the size of our camera
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);
        
        //lerp is liner interpolation
        //go to a new position, from the current position at a set rate
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, camY, this.transform.position.z), smoothRate);
        //go to the smoothed position
        this.transform.position = smoothPos; 
    }

}
