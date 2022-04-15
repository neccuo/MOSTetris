using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareManager : MonoBehaviour
{
    List<GameObject> rows = new List<GameObject>();
    int rowCount = 10;

    public GameObject squareObject;

    int currentRow = 0;

    // GameObject squareObject;

    void Start()
    {
        for(int i = 0; i < rowCount; i++)
        {
            rows.Add(new GameObject("row"+i.ToString()));
            rows[i].transform.SetParent(transform);
            // Instantiate(rows[i]);
        }
        InitializeRow(0);
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            currentRow++;
            if(currentRow < rowCount)
                InitializeRow(currentRow);
        }
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void CreateSquare(int rowNum, int squareOrder, int squareCountForRow)
    {
        GameObject obj = Instantiate(squareObject);

        obj.transform.SetParent(rows[rowNum].transform);
        obj.name = "Square(" + rowNum.ToString() + "-" + squareOrder.ToString() + ")";
        obj.transform.position = new Vector3(squareOrder, rowNum, 0);
        Mover mover = obj.GetComponent<Mover>();
        mover.leftX = squareOrder;
        mover.rightX = 8 - (squareCountForRow-squareOrder); // TODO: GENERALIZE IT, MIGHT HARM THE WORKFLOW
        mover.moveRate = GetMoveRateByRowNum(rowNum);

    }

    void InitializeRow(int rowNum)
    {
        int squareCountForRow = GetSquareCountByRowNum(rowNum);
        // float moveRate = GetMoveRateByRowNum(rowNum);
        
        for(int i = 0; i < squareCountForRow; i++)
        {
            CreateSquare(rowNum, i, squareCountForRow);
        }
    }

    float GetMoveRateByRowNum(int rowNum)
    {
        return 0.1f - (0.0075f * rowNum);
    }

    int GetSquareCountByRowNum(int rowNum)
    {
        if(rowNum < 2)
        {
            return 4;
        }
        else if(rowNum < 6)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    

}
