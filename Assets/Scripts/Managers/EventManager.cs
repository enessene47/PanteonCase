using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    [HideInInspector] public UnityEvent StartEvent = new UnityEvent(); 
}
