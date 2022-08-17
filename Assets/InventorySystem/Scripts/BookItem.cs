using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : InteractionScript
{
    private GameObject playerStatistics;
    public int WisdomIncrease = 5;
    public bool OneTimeUse;
    private bool _used;

    private void Start()
    {
        playerStatistics = Manager.Use<PlayerManager>().Player;
    }
    public override void Interact()
    {
        if (OneTimeUse)
        {
            if (!_used)
            {
                playerStatistics.GetComponent<PlayerStatistics>().IncreaseWisdom(WisdomIncrease);
                _used = true;
                base.Interact();
            }
        }
        else
        {
            playerStatistics.GetComponent<PlayerStatistics>().IncreaseWisdom(WisdomIncrease);
            base.Interact();
        }
    }
}
