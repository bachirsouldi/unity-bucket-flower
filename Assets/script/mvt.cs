using UnityEngine;
using System.Collections;

public class mvt : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Debug.Log(gameObject.name);




        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

    }

}