using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform location;
    private GameObject selectedGameObject;

    private Vector3 outputLocation;
    public GameObject qObject;
    private GameObject wObject;

    public int armor;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }

    public void QAction()
    {
        return;
    }
}
