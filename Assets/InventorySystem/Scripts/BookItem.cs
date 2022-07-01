using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : PickUpItem
{
    private PlayerStatistics playerStatistics;
    public int WisdomIncrease = 5;

    private void Start()
    {
        playerStatistics = Manager.Use<PlayerManager>().Player.GetComponent<PlayerStatistics>();
        base.Start();
    }
    public override void Interact()
    {
        playerStatistics.IncreaseWisdom(WisdomIncrease);
        base.Interact();
    }
}
