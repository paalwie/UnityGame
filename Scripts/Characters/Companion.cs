using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Companion : MonoBehaviour
{
    
    public Transform target;

    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }


    }

    public void teleportCharacter(Vector3 teleportDestination)
    {
        transform.position = teleportDestination;
    }
}
