using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(PlayerStatistics))]
[RequireComponent(typeof(QuestController))]
[RequireComponent(typeof(CircleSync))]
[RequireComponent(typeof(AgentController))]
public class PlayerInteractionScript : MonoBehaviour
{
    public float InteractionRadius;

    private NPCScript _thisNPC;
    private InteractionScript _thisInteraction;

    private Ray _ray;
    private RaycastHit _hit;

    private InventoryScript _inventoryScreen;
    private Text _interactionIndicator;
    private SkilltreeController _skillTree;

    public GameObject OriginPoint;

    private void Start()
    {
        _interactionIndicator = Manager.Use<UIManager>().InteractionIndicator;
        _interactionIndicator.gameObject.SetActive(false);

        _inventoryScreen = Manager.Use<UIManager>().Inventory;
        _inventoryScreen.gameObject.SetActive(false);

        _skillTree = Manager.Use<UIManager>().SkillTree;
        _skillTree.gameObject.SetActive(false);
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(OriginPoint.transform.position + transform.forward * InteractionRadius, InteractionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.GetComponent<TimeConsumer>())
            {
                _interactionIndicator.text = $"Press E to interact (-{hitCollider.gameObject.GetComponent<TimeConsumer>().TimeConsumption} Time)";
            }
            else
            {
                _interactionIndicator.text = $"Press E to interact";
            }

            if (hitCollider.gameObject.GetComponent<NPCScript>())
            {
                _thisNPC = hitCollider.gameObject.GetComponent<NPCScript>();
                _interactionIndicator.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _thisNPC.Interact();
                    //FindObjectOfType<ThirdPersonUserControl>().SetInput(false);
                }
                break;
            }

            if (hitCollider.gameObject.GetComponent<InteractionScript>())
            {
                _thisInteraction = hitCollider.gameObject.GetComponent<InteractionScript>();
                _interactionIndicator.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _thisInteraction.Interact();
                }
                break;
            }

            _interactionIndicator.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryScreen.gameObject.SetActive(!_inventoryScreen.gameObject.active);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _skillTree.gameObject.SetActive(!_skillTree.gameObject.active);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckForNPC();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DropItem();
        }
    }
    void CheckForNPC()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if(_hit.transform.GetComponent<NPCScript>())
            {
                _hit.transform.GetComponent<NPCScript>().ToggleInfoScreen();
            }
        }
    }

    void DropItem()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.GetComponent<InventorySlot>())
            {
                _hit.transform.GetComponent<InventorySlot>().Unassign();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(OriginPoint.transform.position + transform.forward * InteractionRadius, InteractionRadius);

        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
