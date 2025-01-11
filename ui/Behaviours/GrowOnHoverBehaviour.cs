using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class GrowOnHoverBehaviour : MonoBehaviour
{
    public float bigScale, normalScale;

    private EventTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<EventTrigger>();

        var pEnter = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        pEnter.callback.AddListener(eventData => { MakeBig(); });
        trigger.triggers.Add(pEnter);


        var pExit = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        pExit.callback.AddListener(eventData => { MakeNormal(); });
        trigger.triggers.Add(pExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBig()
    {
        transform.localScale = Vector3.one*bigScale;
    }

    public void MakeNormal()
    {
        transform.localScale = Vector3.one*normalScale;
    }
}
