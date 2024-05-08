using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueHandler : MonoBehaviour
{
    public List<GameObject> QueueSpots;
    private GameManager gameManager;
    [SerializeField] private QueueState queueState;
    private Queue<GameObject> npcInQueue;
    private void Start()
    {
        npcInQueue = new();
        gameManager = GetComponent<GameManager>();
        queueState.queueSlots = QueueSpots.Count;
        queueState.availableSlots = QueueSpots.Count;
    }

    Vector3 GetAvailableSlotPosition()
    {
        if (queueState.availableSlots > 0)
        {
            var freeIndex = queueState.queueSlots - queueState.availableSlots;
            return QueueSpots[freeIndex].transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public bool addNpcInQueue(GameObject npcObject)
    {
        if (queueState.availableSlots > 0)
        {
            var availableSlotPosition = GetAvailableSlotPosition();
            if (availableSlotPosition != null && availableSlotPosition != Vector3.zero)
            {
                npcInQueue.Enqueue(npcObject);
                npcObject.GetComponent<NpcController>().moveTo(availableSlotPosition);
                queueState.availableSlots--;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void moveTheQueue()
    {

        for (int i = 0; i < npcInQueue.Count; i++)
        {
            var npcObject = npcInQueue.Dequeue();
            var slotPosition = QueueSpots[i].transform.position;
            npcObject.GetComponent<NpcController>().moveTo(slotPosition);
            npcInQueue.Enqueue(npcObject);
        }

    }


    public void processNpcInFirst(Vector3 platformPosition)
    {

        if (npcInQueue.Count > 0)
        {
            var npcObject = npcInQueue.Dequeue();
            npcObject.GetComponent<NpcController>().moveTo(platformPosition);
            queueState.availableSlots++;
            moveTheQueue();
        }


    }




}
