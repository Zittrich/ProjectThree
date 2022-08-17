using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftingPlace : MonoBehaviour
{
    public List<CraftingIngredient> Ingredients = new();
    private List<CraftingIngredient> InputIngredients = new();
    public GameObject RewardObject;
    [Range(0, 15)] public int WisdomGain;
    [Range(0, 15)] public int SocialGain;

    public Vector2 OverlapDimensions = new(5, 5);

    private GameObject _player;
    private void Start()
    {
        _player = Manager.Use<PlayerManager>().Player;
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.up * OverlapDimensions.x, OverlapDimensions.y);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<CraftingIngredient>())
            {
                if (Ingredients.Contains(hitCollider.gameObject.GetComponent<CraftingIngredient>()))
                {
                    InputIngredients.Add(hitCollider.GetComponent<CraftingIngredient>());
                    hitCollider.gameObject.SetActive(false);
                    if(InputIngredients.Count == Ingredients.Count)
                    {
                        if(RewardObject != null)
                        {
                            Instantiate(RewardObject);
                        }

                        _player.GetComponent<PlayerStatistics>().IncreaseSocial(SocialGain);
                        _player.GetComponent<PlayerStatistics>().IncreaseWisdom(WisdomGain);
                    }
                } 
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * OverlapDimensions.x, OverlapDimensions.y);

        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
