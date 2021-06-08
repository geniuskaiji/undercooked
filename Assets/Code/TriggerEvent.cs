using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public bool requiresTag = true;
    public string tagToHit = "Player";

    public void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("Trigger hit " + collision.gameObject.name);
        if (!collision.gameObject.CompareTag(tagToHit)) {
            return;
        }

        triggerEvent.Invoke();
    }
}
