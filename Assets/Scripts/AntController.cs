/************************************************************************************
FileName: AntController.cs
FileType: Visual C# Source file
Author: VueCode
Description: Controls the ant.
************************************************************************************/
using System.Collections;
using UnityEngine;

public class AntController : MonoBehaviour
{
    [Header("Ant Settings")]
    [Range(0.02f, 1f)]
    public float UpdateTime = 0.025f;                     // Set your own update time (f-seconds)

    [Header("Private Variables")]
    private Vector3 _rotation;                             // ants local roation.



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        StartCoroutine(TickRate());
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        _rotation = transform.eulerAngles;
        if (other.tag == "CellLeft") _rotation.y -= 90;
        if (other.tag == "CellRight") _rotation.y += 90;
    }

    /// <summary>
    /// This function is a custom update loop using the UpdateTime float.
    /// </summary>
    private IEnumerator TickRate()
    {
        while (true)
        {
            transform.eulerAngles = _rotation;
            transform.Translate(Vector3.forward);
            yield return new WaitForSeconds(UpdateTime);
        }
    }
}