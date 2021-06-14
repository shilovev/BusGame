using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    private Man m_Selected;
    [SerializeField]
    private Camera GameCamera;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (m_Selected != null && Input.GetMouseButtonDown(1))
        {
            HandleAction();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bus.Instance.move = true;
        }
    }

    private void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var unit = hit.collider.GetComponentInParent<Man>();
            m_Selected = unit;
        }
    }

    private void HandleAction()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var building = hit.collider.GetComponentInParent<Bus>();

            if (building != null)
            {
                m_Selected.GoTo(building);
            }
            else
            {
                m_Selected.GoTo(hit.point);
            }
        }
    }
}
