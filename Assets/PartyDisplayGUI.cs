using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyDisplayGUI : MonoBehaviour
{
    public Image[] images;
    public Color validColor;
    public Color invalidColor;

    MonsterParty party;

    public void SetParty(MonsterParty _party)
    {
        party = _party;
        UpdateParty();
    }

    public void UpdateParty()
    {
        for (int i = 0; i < party.members.Length; i++)
        {
            if (party.members[i].validForBattle)
            {
                images[i].color = validColor;
                images[i].sprite = party.members[i].species.partySprite;
            }
            else
            {
                images[i].color = invalidColor;
            }
        }
    }
}
