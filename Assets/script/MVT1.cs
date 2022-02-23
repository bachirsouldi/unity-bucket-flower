using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVT1 : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    bool rotation = true;
    bool positionZ;
    RaycastHit hit;
    GameObject selectedItem;


    private void Start()
    {
        positionZ = true;
        Debug.Log("start");
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (selectedItem)
            {


                if (positionZ)
                {

                    selectedItem.transform.position = selectedItem.transform.position + Vector3.forward;

                }
                else
                {

                    selectedItem.transform.position = selectedItem.transform.position - Vector3.forward;
                }

            }

        }
    }

    void OnMouseDown()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            selectedItem = hit.transform.gameObject;
        }

        zCoord = Camera.main.WorldToScreenPoint(selectedItem.transform.position).z;

        offset = selectedItem.transform.position - GameMouseWorldPos();

    }

    private Vector3 GameMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {

        if (selectedItem)
        {

            if (Input.GetMouseButtonDown(1))
            {

                Vector3 eulerAngle = selectedItem.transform.rotation.eulerAngles;
                if (rotation)
                {
                    selectedItem.transform.rotation = Quaternion.Euler(new Vector3(
                        eulerAngle.x,
                        eulerAngle.y + 45,
                        eulerAngle.z
                        ));
                }
                else
                {


                    selectedItem.transform.rotation = Quaternion.Euler(new Vector3(
                       eulerAngle.x,
                       eulerAngle.y - 45,
                       eulerAngle.z
                       ));
                }
            }

            selectedItem.transform.position = GameMouseWorldPos() + offset;
        }
    }

    private void OnMouseExit()
    {
        positionZ = !positionZ;
        rotation = !rotation;
        selectedItem = null;
    }
}
