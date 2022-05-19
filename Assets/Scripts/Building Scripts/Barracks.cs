using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Building
{
    public new void QAction()
    {
        Vector3 outputLocation = new Vector3(location.position.x - 1, location.position.y - 2, location.position.z);
        Debug.Log(outputLocation);
        Instantiate(qObject, outputLocation, location.rotation);
    }

}
