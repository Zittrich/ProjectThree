using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerInteractionScript : MonoBehaviour
{
    public float InteractionRadius;
    private NPCScript _thisNPC;
    private InteractionScript _thisInteraction;
    private Ray _ray;
    private RaycastHit _hit;

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
                    FindObjectOfType<ThirdPersonUserControl>().SetInput(false);
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

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckForNPC();
        }
    }
    void CheckForNPC()
    {
        _ray = GameObject.FindGameObjectWithTag("ViewCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if(_hit.transform.GetComponent<NPCScript>())
            {
                _hit.transform.GetComponent<NPCScript>().ToggleInfoScreen();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * InteractionRadius, InteractionRadius);

        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
