using System;
using UnityEngine;

public class ObjectGrabBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    private Grab _objectGrabbedTransform;
    private bool _isGrabbed = false;

    private void Update()
    {
        if (_isGrabbed)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo))
            {
                transform.position = hitInfo.point;
            }
        }
    }

    public void Grab(Grab grabComponent)
    {
        this._objectGrabbedTransform = grabComponent;
        _isGrabbed = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.SetParent(grabComponent.transform);
        
        // if(_rb == null)
        //     _rb = gameObject.AddComponent<Rigidbody>();
        //
        // _rb.useGravity = false;
        // _rb.linearVelocity = Vector3.zero;
        // _rb.angularVelocity = Vector3.zero;
        // _rb.isKinematic = true;
    }

    public void Drop()
    {
        _isGrabbed = false;
        _objectGrabbedTransform = null;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.SetParent(null);

        //fazer ray cast 
    }
    
}
