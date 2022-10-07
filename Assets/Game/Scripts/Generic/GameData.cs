using System;

[Serializable]

public class GameData
{
    public bool IsEnterGame { get; private set; }
    public string ImageName { get; private set; }
    public int Money { get; private set; }
    public int MaxMoney { get; private set; }
    public int NumberSelectField { get; private set; }
    public int CountReelsKilledZombi { get; private set; }

    public void  FirstUpdateDate(Player player,Wallet wallet,Harvester harvester)
    {
        IsEnterGame = player.IsEnterGame;
        ImageName = player.ImageName;
        Money = wallet.Money;
        MaxMoney = wallet.MaxMoney;
        CountReelsKilledZombi=harvester.CountReelsKilledZombi;
    }
    public void HomeUpdateDate(FieldSelecterStatus fieldSelecterStatus)
    {
        NumberSelectField=fieldSelecterStatus.NumberSelectField;
    }
}
