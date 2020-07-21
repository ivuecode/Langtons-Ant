/************************************************************************************
FileName: CellUpdater.cs
FileType: Visual C# Source file
Author: VueCode
Description: Updates the color of each cell.
************************************************************************************/
using UnityEngine;

public class CellUpdater : MonoBehaviour
{
    [Header("Component References")]
    public Material ActiveCell;
    public Material EmptyCell;

    [Header("Private Variables")]
    private bool _isEmpty = true;
    private MeshRenderer _renderer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ant")
        {
            if (_isEmpty)
            {
                // get the ants color and set the active color here
                _renderer.material.color = other.GetComponent<AntController>().AntColor;
                // _renderer.material = ActiveCell;
                gameObject.tag = "CellRight";
            }
            if (!_isEmpty)
            {
                _renderer.material = EmptyCell;
                gameObject.tag = "CellLeft";
            }
            _isEmpty = !_isEmpty;
        }
    }
}