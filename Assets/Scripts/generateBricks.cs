using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// make a new brick stamp
public class brick : MonoBehaviour
{
    public new GameObject gameObject;
    public Material brickMat;
    public GameObject brickController;
}


public class generateBricks : MonoBehaviour
{
    public GameObject brickPrefab;
    public float padding = 0.2f;
    public int rows;
    public int columns;
    public brick[,] arrayOfBricks;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        
        Debug.Log(columns);
        createBricks();
    

    }
    void createBricks()
    {
        // Create an array inside an array
        arrayOfBricks = new brick[columns, rows];

        // creat a cursor that will move after every instatiate
        Vector3 cursor = new Vector3();


        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                //STAMP, Instatiate brick, set the parent to the brick generator, establish where cursor is
                brick currentBrick = new brick();
                currentBrick.gameObject = GameObject.Instantiate(brickPrefab);
                currentBrick.gameObject.transform.SetParent(transform);
                currentBrick.gameObject.transform.localPosition = cursor;
                // Assign all that mess to the array inside the array, I think
                arrayOfBricks[i, j] = currentBrick;
                // move the cursor along y axis
                cursor.y -= padding;

                //makes a grid with huge padding which sucks
                //Instantiate(brickPrefab, new Vector3(x, y, 0), Quaternion.identity); */

            }
            // keeps cursor still along y axis, does x axis instead
            cursor.y = 0;
            cursor.x += padding;


        }
    }





    // Update is called once per frame
    void Update()
    {

    }
}

