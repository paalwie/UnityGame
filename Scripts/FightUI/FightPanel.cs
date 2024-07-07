using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class FightPanel : MonoBehaviour {

    // attacker
    public Text attackerName;

    public Image attackerImage;

    public Text attackerAttack;

    public Text attackerDefense;

    public Text attackerThoughness;

    public Text attackerLifePoints;

    // defender
    public Text defenderName;

    public Image defenderImage;

    public Text defenderAttack;

    public Text defenderDefense;

    public Text defenderThoughness;

    public Text defenderLifePoints;

    // UI

    public Button fightButton;

    public Button fleeButton;

    public GameObject fightPanelObject;

    private static FightPanel fightPanel;

    public static FightPanel Instance ()
    {
        if (!fightPanel)
        {
            fightPanel = FindObjectOfType(typeof(FightPanel)) as FightPanel;
        }

        return fightPanel;
    }

    public void fightPlayerVsPlayer (UnityAction fightEvent, UnityAction fleeEvent, Player Attacker, Player Defender)
    {
        attackerName.text = Attacker.characterName;
        attackerAttack.text = "Angriff: " + Attacker.attack.ToString();
        attackerDefense.text = "Verteidigung: " + Attacker.defense.ToString();
        attackerThoughness.text = "Zähigkeit: " + Attacker.toughness.ToString();
        attackerLifePoints.text = "Lebenspunkte: " + Attacker.lifePoints.ToString();

        defenderName.text = Defender.characterName;
        defenderAttack.text ="Angriff: " + Defender.attack.ToString();
        defenderDefense.text = "Verteidigung: " + Defender.defense.ToString();
        defenderThoughness.text ="Zähigkeit: " + Defender.toughness.ToString();
        defenderLifePoints.text = "Lebenspunkte: " + Defender.lifePoints.ToString();
        defenderThoughness.enabled = true;
        defenderLifePoints.enabled = true;

        fightPanelObject.SetActive(true);
        fightButton.onClick.RemoveAllListeners();
        fightButton.onClick.AddListener(fightEvent);
        fightButton.onClick.AddListener(ClosePanel);

        fleeButton.onClick.RemoveAllListeners();
        fleeButton.onClick.AddListener(fleeEvent);
        fleeButton.onClick.AddListener(ClosePanel);
    }

    public void fightPlayerVsNPC(UnityAction NPCFightEvent, UnityAction fleeEvent, Player Attacker, NPC Defender)
    {
        attackerName.text = Attacker.characterName;
        attackerAttack.text = "Angriff: " + Attacker.attack.ToString();
        attackerDefense.text = "Verteidigung: " + Attacker.defense.ToString();
        attackerThoughness.text = "Zähigkeit: " + Attacker.toughness.ToString();
        attackerLifePoints.text = "Lebenspunkte: " + Attacker.lifePoints.ToString();

        defenderName.text = Defender.characterName;
        defenderAttack.text = "Angriff: " + Defender.attack.ToString();
        defenderDefense.text = "Verteidigung: " + Defender.defense.ToString();
        defenderThoughness.enabled = false;
        defenderLifePoints.enabled = false;
       


        fightPanelObject.SetActive(true);
        fightButton.onClick.RemoveAllListeners();
        fightButton.onClick.AddListener(NPCFightEvent);
        fightButton.onClick.AddListener(ClosePanel);

        fleeButton.onClick.RemoveAllListeners();
        fleeButton.onClick.AddListener(fleeEvent);
        fleeButton.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        fightPanelObject.SetActive(false);
    }

}
