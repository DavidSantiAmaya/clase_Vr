using UnityEngine;

public class AgarraObjeto : MonoBehaviour
{
    public bool esAgarrable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
            AudioManager.Instance.Play2D("Sonido_1");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
            AudioManager.Instance.Play2D("Sonido_3");
        }
    }
}
