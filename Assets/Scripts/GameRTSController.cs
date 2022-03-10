using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{

    public Camera cam;

    private List<Unit> selectedUnitList;

    [SerializeField] private Transform selectionAreaTransform;

    public Vector3 worldPos;
    private Vector3 startPos;
    private Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        worldPos = new Vector3(0.0f, 0.0f);

        selectedUnitList = new List<Unit>();
        selectionAreaTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MouseActions();
    }

    void MouseActions()
    {

        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // ==============
        // Unit Selection
        // ==============
        if (Input.GetMouseButtonDown(0))
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // Transform selection box
        if (Input.GetMouseButton(0))
        {

            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPos.x, worldPos.x),
                Mathf.Min(startPos.y, worldPos.y));
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPos.x, worldPos.x),
                Mathf.Max(startPos.y, worldPos.y));
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if(Input.GetMouseButtonUp(0))
        {
            selectionAreaTransform.gameObject.SetActive(false);
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Deselect old units
            foreach (Unit unit in selectedUnitList)
            {
                unit.SetSelectedVisible(false);
            }
            selectedUnitList.Clear();

            // Select new units
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPos, endPos);
            foreach (Collider2D collider2D in collider2DArray)
            {
                Unit unit = collider2D.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.SetSelectedVisible(true);
                    selectedUnitList.Add(unit);
                }

                Debug.Log(selectedUnitList.Count);
            }
        }


    }
}
