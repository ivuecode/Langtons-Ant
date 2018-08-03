/************************************************************************************
FileName: MouseController.cs
FileType: Visual C# Source file
Author: VueCode
Description: Spawns a new ant at the given cell position
************************************************************************************/
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Component References")]
    public MapGenerator mapGenerator;                      // Map generator ref.
    public GameObject AntPrefab;                           // Ant prefab.
    public Color[] HeadColors;                             // Ant color head.

    [Header("Private Variables")]
    private Camera Mycamera;                               // Scene Camera.
    private float _sensitivity = 10F;
    private readonly float _cameraSize;
    private readonly float minSize = 10F;
    private readonly float maxSize = 500F;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Mycamera = GetComponent<Camera>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MouseClickAnt();
        MouseZoomControl();
    }

    /// <summary>
    /// Detect a mouse click and spawn a new ant at that location.
    /// </summary>
    private void MouseClickAnt()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null && Input.GetMouseButtonDown(0))
            {
                GameObject ant = Instantiate(AntPrefab, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);
                ant.GetComponentInChildren<MeshRenderer>().material.color = HeadColors[Random.Range(0, HeadColors.Length)];
            }
        }
    }

    /// <summary>
    /// This function allows for mouse scroll
    /// </summary>
    private void MouseZoomControl()
    {
        if (Input.GetKey(KeyCode.LeftControl)) _sensitivity = 40F;
        else _sensitivity = 10F;

        float fov = Mycamera.orthographicSize;
        fov -= Input.GetAxis("Mouse ScrollWheel") * _sensitivity;
        fov = Mathf.Clamp(fov, minSize, maxSize);
        Mycamera.orthographicSize = fov;
    }
}