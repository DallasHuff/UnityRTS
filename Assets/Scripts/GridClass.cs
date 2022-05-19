using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass
{
    private int width;
    private int height;
    private float cellsize;
    private int[,] gridarray;
    private Vector3 originPosition;

    public GridClass(int width, int height, float cellsize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        this.originPosition = originPosition;

        gridarray = new int[width, height];

        Troubleshoot();
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellsize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellsize);
    }
    
    public void Troubleshoot()
    {
        for (int x = 0; x < gridarray.GetLength(0); x++)
        {
            for (int y = 0; y < gridarray.GetLength(1); y++)
            {
                Debug.Log(x + ", " + y + ", " + gridarray[x, y].ToString());
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 1f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 1f) ;
            }
        }
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridarray[x, y] = value;
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridarray[x, y];
        } else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
