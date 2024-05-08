using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "QueueState", menuName = "QueueState", order = 0)]
public class QueueState : ScriptableObject
{

    public int queueSlots = 0;
    public int availableSlots = 0;

}