using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public bool esAgarrable = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
            AudioManager.Instance.Play2D("Detectar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
            AudioManager.Instance.Play2D("NoDetectar");
        }
    }
}
