using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class brick : MonoBehaviour
{
    public new GameObject gameObject;
    public Material brickMat;
    public GameObject brickController;
}


public class generateBricks : MonoBehaviour
{
    public GameObject brickPrefab;
    public float padding;
    public int rows;
    public int columns;
    public brick[,] arrayOfBricks;


    // Start is called before the first frame update
    void Start()
    {
        arrayOfBricks = new brick[columns, rows];
        for (int i = 0; i < columns; i++){
            for(int j = 0; j < rows; j++){
                brick theBrick = new brick();
                theBrick.gameObject = GameObject.Instantiate(brickPrefab);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
