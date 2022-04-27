using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionScript : MonoBehaviour
{
    public float InteractionRadius;
    private NPCScript _thisNPC;
    private InteractionScript _thisInteraction;

    public Text InteractionDisplay;
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward * InteractionRadius, InteractionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<NPCScript>())
            {
                _thisNPC = hitCollider.gameObject.GetComponent<NPCScript>();
                InteractionDisplay.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _thisNPC.Interact();
                    GetComponent<ThirdPersonUserControl>()
                }
                break;
            }

            if (hitCollider.gameObject.GetComponent<InteractionScript>())
            {
                _thisInteraction = hitCollider.gameObject.GetComponent<InteractionScript>();
                InteractionDisplay.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _thisInteraction.Interact();
                }
                break;
            }

            InteractionDisplay.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * InteractionRadius, InteractionRadius);
    }
}
