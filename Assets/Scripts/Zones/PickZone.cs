using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PickZone : CardList
{
    public override GameObject Draw()
    {
        GameObject card = base.Draw();
        if (card == null)
        {
            ResetPick();
            return base.Draw();
        }
        return card;
    }
    public void ResetPick()
    {
        Add(Zones.Instance.Discard.Cards.ToArray());
        Zones.Instance.Discard.Cards.Clear();
        Shuffle();
    }
}
