using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private GridClass grid;
    Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GridClass(6, 2, 1f, new Vector3(-5, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        grid.Troubleshoot();

        if (Input.GetMouseButtonDown(0))
        {
            worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            grid.SetValue(worldPosition, 2);
        }
    }
}
