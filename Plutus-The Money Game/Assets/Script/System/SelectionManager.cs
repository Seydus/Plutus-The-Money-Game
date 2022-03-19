using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; set; }

    RaycastHit2D hit;

    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    //private Draggable _lastDragged;

    public float price;
    private bool _isDragActive = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(_isDragActive && Input.GetMouseButtonUp(0))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            hit = Physics2D.Raycast(_worldPosition, Vector2.zero);

            if (hit.collider != null)
            {
                //Draggable itemsInfo = hit.transform.gameObject.GetComponent<Draggable>();

                //if (itemsInfo != null)
                //{
                //    _lastDragged = itemsInfo;
                //    InItDrag();
                //}

            }
        }
    }

    private void InItDrag()
    {
        _isDragActive = true;
    }

    private void Drag()
    {
        //_lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    private void Drop()
    {
        _isDragActive = false;
    }
}
