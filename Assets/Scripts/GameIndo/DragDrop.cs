using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDropHandler
{
    public bool isEmpty = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (isEmpty)
        {
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
                eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector3(eventData.pointerDrag.GetComponent<RectTransform>().position.x, eventData.pointerDrag.GetComponent<RectTransform>().position.y, 5f);
            }

        }

    }


    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 100f );
        if (hit.collider != null)
        {
            isEmpty = false;
        }
        else
        {
            isEmpty = true;
        }

    }

}
