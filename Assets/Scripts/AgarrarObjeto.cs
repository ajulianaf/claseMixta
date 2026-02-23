using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public bool esAgarrable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
