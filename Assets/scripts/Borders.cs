using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    //script for game boundaries, with orthographic camera 
    public Camera mainCamera; 
    private Vector2 screenBoundary;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBoundary = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width or height / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBoundary.x * -1 + objectWidth, screenBoundary.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundary.y * -1 + objectHeight, screenBoundary.y - objectHeight);
        transform.position = viewPos; 
    }
}
