using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ViewportHandler : MonoBehaviour
{
    private float screenwidth;
    private float screenheight;

    Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
        screenwidth = Screen.width;
        screenheight = Screen.height;

        camera.orthographicSize = 20 / screenwidth * screenheight / 2;

    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        
    }
}