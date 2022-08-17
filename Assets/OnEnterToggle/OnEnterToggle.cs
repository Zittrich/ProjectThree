using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterToggle : MonoBehaviour
{
    public GameObject Grid;
    public int MinInactiveGridLayer;
    public float Delay = 1;
    private float _lastTime;

    private List<GameObject> _toggleList = new List<GameObject>();

    private void Start()
    {
        _lastTime = Time.time;
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
                _lastTime = Time.time;

                if(_lastTime + Delay <= Time.time)
                    o.SetActive(!o.active);
            }
        }
    }
}
