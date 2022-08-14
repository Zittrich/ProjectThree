using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterToggle : MonoBehaviour
{
    public GameObject Grid;
    public int MinInactiveGridLayer;

    private List<GameObject> _toggleList = new List<GameObject>();
    public bool TurnOn;

    private void Start()
    {
        for (int i = MinInactiveGridLayer; i <= Grid.transform.childCount - 1; i++)
        {
            _toggleList.Add(Grid.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        Collider[] hit =
            Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);

        if (hit[0].transform.GetComponent<PlayerInteractionScript>())
        {
            foreach (GameObject o in _toggleList)
            {
                o.SetActive(TurnOn);
            }
        }
        Debug.Log("Enter");
    }
}
