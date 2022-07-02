using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : InteractionScript
{
    private PlayerStatistics playerStatistics;
    public int WisdomIncrease = 5;
    public bool OneTimeUse;
    private bool _used;

    private void Start()
    {
        playerStatistics = Manager.Use<PlayerManager>().Player.GetComponent<PlayerStatistics>();
    }
    public override void Interact()
    {
        if (OneTimeUse)
        {
            if (!_used)
            {
                playerStatistics.IncreaseWisdom(WisdomIncrease);
                _used = true;
                base.Interact();
            }
        }
        else
        {
            playerStatistics.IncreaseWisdom(WisdomIncrease);
            base.Interact();
        }
    }
}
