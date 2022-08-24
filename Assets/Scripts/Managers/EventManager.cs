using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    [HideInInspector] public UnityEvent StartEvent = new UnityEvent(); 
}
