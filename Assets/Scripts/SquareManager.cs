using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareManager : MonoBehaviour
{
    [SerializeField] List<GameObject> rows = new List<GameObject>();
    int rowCount = 10;

    int colCount = 8;

    public GameObject squareObject;

    public GameObject rowObject;

    int currentRow = 0;

    HashSet<int> availableX = new HashSet<int>();

    // GameObject squareObject;

    void Start()
    {
        for(int i = 0; i < rowCount; i++)
        {
            GameObject row = Instantiate(rowObject); //new GameObject("row"+i.ToString());
            row.name = "row"+i.ToString();
            rows.Add(row);
            rows[i].transform.SetParent(transform);
            // Instantiate(rows[i]);
        }
        InitializeRow(0);
        InitializeAvailableX(colCount);
    }

    public bool PlayMove()
    {
        if(!IsMoveValid())
            return false;

        Debug.Log("Move valid");
        StopSquares(currentRow);
        currentRow++;
        if(currentRow < rowCount)
            InitializeRow(currentRow);
        return true;
    }

    public bool IsWin()
    {
        return currentRow == rowCount;
    }

    public void StopCurrentSquares()
    {
        StopSquares(currentRow);
    }

    void StopSquares(int rowNum)
    {
        var row = rows[rowNum];
        int childCount = row.transform.childCount;
        for(int i = 0; i < childCount; ++i)
        {
            Mover mover = row.transform.GetChild(i).GetComponent<Mover>();
            mover.Stop();
        }
    }

    bool IsMoveValid()
    {
        if(currentRow >= rowCount)
        {
            Debug.Log("Game should've ended");
            return false;
        }

        HashSet<int> mySet = new HashSet<int>();
        var row = rows[currentRow];
        int childCount = row.transform.childCount;
        for(int i = 0 ; i < childCount; ++i)
        {
            int x = (int) row.transform.GetChild(i).position.x;
            if(availableX.Contains(x))
                mySet.Add(x);
        }
        if(mySet.Count == 0)
        {
            Debug.Log("Invalid move");
            return false;
        }

        availableX = new HashSet<int>(mySet);
        return true;
    }

    void CreateSquare(int rowNum, int squareOrder, int squareCountForRow)
    {
        GameObject obj = Instantiate(squareObject);

        RowBrain rowBrain = rows[rowNum].GetComponent<RowBrain>();

        obj.transform.SetParent(rowBrain.transform);
        obj.name = "Square(" + rowNum.ToString() + "-" + squareOrder.ToString() + ")";
        obj.transform.position = new Vector3(squareOrder, rowNum, 0);
        rowBrain.squareList.Add(obj);
        
        Mover mover = obj.GetComponent<Mover>();
        mover.leftX = squareOrder;
        mover.rightX = colCount - (squareCountForRow-squareOrder); // TODO: GENERALIZE IT, MIGHT HARM THE WORKFLOW
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

    void InitializeAvailableX(int count)
    {
        for(int i = 0; i < count; ++i)
        {
            availableX.Add(i);
        }
    }

    float GetMoveRateByRowNum(int rowNum)
    {
        if(rowCount >= 13)
            return 0.1f - (0.0075f * 13); 
        return 0.1f - (0.0075f * rowNum);
    }

    public float GetCurrentMoveRate()
    {
        return GetMoveRateByRowNum(currentRow);
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
