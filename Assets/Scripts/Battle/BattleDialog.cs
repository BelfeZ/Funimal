using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    [SerializeField] private int lettersPerSecond;
    [SerializeField] private Color highlightedColor;
    
    [SerializeField] private Text dialogText;
    [SerializeField] private GameObject orderSelector;
    [SerializeField] private GameObject skillPlayer1Selector;
    [SerializeField] private GameObject skillPlayer2Selector;

    [SerializeField] private List<Text> orderTexts;
    [SerializeField] private List<Text> skillPlayer1Texts;
    [SerializeField] private List<Text> skillPlayer2Texts;
    [SerializeField] private List<Text> skillSpPlayer1Texts;
    [SerializeField] private List<Text> skillSpPlayer2Texts;
    [SerializeField] private List<Text> player1StatusTexts;
    [SerializeField] private List<Text> player2StatusTexts;

    private int[] player1BuffOrder = new int[4];
    private int[] player2BuffOrder = new int[4];
    
    /*public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }*/

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    /*public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }*/
    
    public void EnableOrderSelector(bool enabled)
    {
        orderSelector.SetActive(enabled);
    }
    
    public void EnableSkillSelector(bool enabled , int player)
    {
        if (player == 1)
        {
            skillPlayer1Selector.SetActive(enabled);
        }
        if (player == 2)
        {
            skillPlayer2Selector.SetActive(enabled);
        }
    }

    public void UpdateOrderSelection(int selectedAction)
    {
        for (int i = 0; i < orderTexts.Count; i++)
        {
            if (i == selectedAction)
            {
                orderTexts[i].color = highlightedColor;
            }
            else
            {
                orderTexts[i].color = Color.black;
            }
        }
    }

    public void UpdateSkillSelection(int selectedSkill, Move skill , int player)
    {
        if (player == 1)
        {
            for (int i = 0; i < skillPlayer1Texts.Count; i++)
            {
                if (i == selectedSkill)
                {
                    skillPlayer1Texts[i].color = highlightedColor;
                }
                else
                {
                    skillPlayer1Texts[i].color = Color.black;
                }
            }
        }
        else if (player == 2)
        {
            for (int i = 0; i < skillPlayer2Texts.Count; i++)
            {
                if (i == selectedSkill)
                {
                    skillPlayer2Texts[i].color = highlightedColor;
                }
                else
                {
                    skillPlayer2Texts[i].color = Color.black;
                }
            }
        }
    }

    public void UpdateStatusForPlayer1(int type)
    {
        for (int i = 0; i < player1StatusTexts.Count; i++)
        {
            if (player1BuffOrder[i] == 0)
            {
                if (type == 1)
                {
                    player1StatusTexts[i].text = "ATK↑";
                    player1BuffOrder[i] = 1;
                    break;
                }
                if (type == 2)
                {
                    player1StatusTexts[i].text = "DEF↑";
                    player1BuffOrder[i] = 2;
                    break;
                }
                if (type == 3)
                {
                    player1StatusTexts[i].text = "ATK&DEF↑";
                    player1BuffOrder[i] = 3;
                    break;
                }
                if (type == 4)
                {
                    player1StatusTexts[i].text = "ATK↓";
                    player1BuffOrder[i] = 4;
                    break;
                }
                if (type == 5)
                {
                    player1StatusTexts[i].text = "DEF↓";
                    player1BuffOrder[i] = 5;
                    break;
                }
                if (type == 6)
                {
                    player1StatusTexts[i].text = "ATK&DEF↓";
                    player1BuffOrder[i] = 6;
                    break;
                }
            }
        }
    }
    
    public void RemoveStatusForPlayer1(int order)
    {
        player1BuffOrder[order] = 0;
        player1StatusTexts[order].text = "";
    }
    
    public void RemoveStatusForPlayer2(int order)
    {
        player2BuffOrder[order] = 0;
        player2StatusTexts[order].text = "";
    }

    public void UpdateStatusForPlayer2(int type)
    {
        for (int i = 0; i < player2StatusTexts.Count; i++)
        {
            if (player2BuffOrder[i] == 0)
            {
                if (type == 1)
                {
                    player2StatusTexts[i].text = "ATK↑";
                    player2BuffOrder[i] = 1;
                    break;
                }
                else if (type == 2)
                {
                    player2StatusTexts[i].text = "DEF↑";
                    player2BuffOrder[i] = 2;
                    break;
                }
                else if (type == 3)
                {
                    player2StatusTexts[i].text = "ATK&DEF↑";
                    player2BuffOrder[i] = 3;
                    break;
                }
                else if (type == 4)
                {
                    player2StatusTexts[i].text = "ATK↓";
                    player2BuffOrder[i] = 4;
                    break;
                }
                else if (type == 5)
                {
                    player2StatusTexts[i].text = "DEF↓";
                    player2BuffOrder[i] = 5;
                    break;
                }
                else if (type == 6)
                {
                    player2StatusTexts[i].text = "ATK&DEF↓";
                    player2BuffOrder[i] = 6;
                    break;
                }
            }
        }
    }
    
    public void SetSkillNamesForPlayer1(List<Move> skills)
    {
        for (int i = 0; i < skillPlayer1Texts.Count; i++)
        {
            if (i < skills.Count)
            {
                skillPlayer1Texts[i].text = skills[i].Base.Name;
                skillSpPlayer1Texts[i].text = skills[i].Base.SpCost+" SP";
            }
            else
            {
                skillPlayer1Texts[i].text = "-";
                skillSpPlayer1Texts[i].text = "";
            }
        }
    }
    
    public void SetSkillNamesForPlayer2(List<Move> skills)
    {
        for (int i = 0; i < skillPlayer2Texts.Count; i++)
        {
            if (i < skills.Count)
            {
                skillPlayer2Texts[i].text = skills[i].Base.Name;
                skillSpPlayer2Texts[i].text = skills[i].Base.SpCost+" SP";
            }
            else
            {
                skillPlayer2Texts[i].text = "-";
                skillSpPlayer2Texts[i].text = "";
            }
        }
    }
}
