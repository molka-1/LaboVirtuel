using UnityEngine;
using TMPro;

public class PrepZone : MonoBehaviour
{
    public TMP_Text label;   // le texte UI (on le glisse dans l'Inspector)
    int count = 0;           // nombre d'outils dans la zone

    void Start() { UpdateUI(); }

    // Appelé automatiquement quand un objet ENTRE dans la zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Equipment")) { count++; UpdateUI(); }
    }

    // Appelé automatiquement quand un objet SORT de la zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Equipment")) { count--; UpdateUI(); }
    }

    void UpdateUI()
    {
        // Cherche tous les objets avec le tag Equipment dans la scène
        int total = GameObject.FindGameObjectsWithTag("Equipment").Length;
        label.text = "Matériel prêt : " + count + "/" + total;
        if (count == total) label.text += "  - Tout est prêt !";
    }
}