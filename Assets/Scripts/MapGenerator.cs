/************************************************************************************
FileName: MapGenerator.cs
FileType: Visual C# Source file
Author: VueCode
Description: Generates a new tilemap for the ant(s).
************************************************************************************/
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Component References")]
    public GameObject EmptyCell;                           // Empty cell gameobject.

    [Header("Board Settings")]
    public int BoardSize;                                  // The width * height of game board

    [Header("Private Variables")]
    private GameObject[,] _boardArray;                     // Board array 2D.


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public void Start()
    {
        GenerateMap(BoardSize);
    }

    /// <summary>
    /// Generates a new map with the cell size
    /// </summary>
    public void GenerateMap(int size)
    {
        // Setup prerequisites
        _boardArray = new GameObject[size, size];
        GameObject tileContainer = new GameObject();
        tileContainer.name = "Tile Container";

        // Generate a grid of empty tiles.
        for (int i = 0; i < _boardArray.GetLength(0); i++)
        {
            for (int j = 0; j < _boardArray.GetLength(1); j++)
            {
                GameObject tmp = _boardArray[i, j] = Instantiate(EmptyCell, new Vector3(j - size / 2, 0, i - size / 2), Quaternion.identity);
                tmp.name = i.ToString() + j.ToString();
                tmp.transform.SetParent(tileContainer.transform);
            }
        }
    }
}