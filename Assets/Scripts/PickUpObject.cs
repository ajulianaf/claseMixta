using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform ZonadeInteraccion;
    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<AgarrarObjeto>().esAgarrable == true && PickedObject == null) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = false;
                PickedObject.transform.SetParent(ZonadeInteraccion);
                PickedObject.transform.position = ZonadeInteraccion.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        } else if (PickedObject != null )
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
