using UnityEngine;
using UnityEngine.AI;    // nécessaire pour NavMeshAgent

public class Robot : MonoBehaviour
{
    public Transform etagere;    // destination 1
    public Transform paillasse;  // destination 2
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   // récupère le composant du robot
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) agent.SetDestination(etagere.position);
        if (Input.GetKeyDown(KeyCode.T)) agent.SetDestination(paillasse.position);
    }
}