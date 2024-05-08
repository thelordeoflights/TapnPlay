using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveTo(Vector3 position)
    {
        Debug.Log("POSITION" + position);

        agent.SetDestination(position);

        // agent.Move(position);
    }

}
