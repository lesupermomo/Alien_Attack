﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
public class MouseManger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hoveredObject;
    public GameObject selectedObject;
    //public PlayerMotor motor;

    void Start()
    {
      //  motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;


        if(Physics.Raycast(ray, out hitInfo))//hitInfo takes the object hit
        {
            GameObject hitObject = hitInfo.transform.root.gameObject;
          
            HoverObject(hitObject);

        }
        else
        {
            ClearHover();//the mouse is hovering over something empty
        }

        if (Input.GetMouseButtonDown(0))//0 is left 1 is right 2 middle button down
        {
            if ((selectedObject == null) && (hoveredObject.CompareTag("Player")))
            {
                selectedObject = hoveredObject;
               
            }
            if(selectedObject!=null)
            {
                SelectObject(hoveredObject, hitInfo); //move player or whatever we would want to do
            }
        }

        if (Input.GetMouseButtonDown(1))//0 is left 1 is right 2 middle button down
        {
            if (selectedObject != null)
            {
                selectedObject = null;
            }
        }

    }

    void HoverObject(GameObject obj)
    {
        if (hoveredObject != null)
        {
            if (obj == hoveredObject)
                return;
           // ClearHover();
        }
        hoveredObject = obj;//if it did not return than modify what the hovered object is
    }

    void SelectObject(GameObject obj, RaycastHit hitInfo)
    {
        if (obj != null)
        {
            if (obj.CompareTag("Enemy"))
            {
                Debug.Log("attack " + obj);
            }
            else {

                // selectedObject.GetComponent<NavMeshAgent>().SetDestination(obj.transform.position);
                selectedObject.GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);

            }
            
        }
    }

    void ClearHover()
    {
        hoveredObject = null;
    }
}
