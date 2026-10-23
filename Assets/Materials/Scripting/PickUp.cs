using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject held;   // l'objet qu'on tient (null = rien dans la main)

    void Update()
    {
        // Rayon qui part de la caméra et passe par la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))            // clic gauche
        {
            if (held == null)                       // main vide → on essaie de prendre
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 100f,
                        Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore)
                    && hit.collider.CompareTag("Equipment"))
                {
                    held = hit.collider.gameObject;
                    held.GetComponent<Rigidbody>().isKinematic = true;  // plus de gravité
                    held.layer = 2;                 // "Ignore Raycast" pendant qu'on le tient
                }
            }
            else                                    // on tient déjà → on lâche
            {
                held.GetComponent<Rigidbody>().isKinematic = false;    // la gravité revient
                held.layer = 0;
                held = null;
            }
        }

        // Si on tient un objet, il suit la souris (0.5 m au-dessus de la surface visée)
        if (held != null && Physics.Raycast(ray, out RaycastHit h2, 100f,
                Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
        {
            held.transform.position = h2.point + Vector3.up * 0.5f;
        }
    }
}