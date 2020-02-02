using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    TextMeshProUGUI TutorialText;
    TextMeshProUGUI NextButton;
    [SerializeField] GameObject MainMenu;
    public void Start()
    {
        TutorialText = this.gameObject.transform.Find("Tutorial Pages").GetComponentInChildren<TextMeshProUGUI>();
        NextButton = this.gameObject.transform.Find("Next").Find("Text").GetComponent<TextMeshProUGUI>();
        TutorialText.text = TutorialTexts[page];
    }

    int page = 0;
    string[] TutorialTexts = new string[]{"Welcome to ShipWright!\n\nA co-op game!",
        "One player controls the shipwright,\nthe other controls the cannons.\n\nThe shipwright has to repair the ship\nfrom the onslaught from the seas and skies.",
        "Shipwright Controls:\n\nWASD to move\nStand still and hold spacebar to build a cannon\nHold spacebar + left or right to build in that direction", "Gunner Controls:\n\nEnter to fire\nLeft and right arrows to turn cannon\nNum 1 previous cannon/Num 3 next cannon", "Anchor Controls:\n\nNumpad + to swap to anchor (arrow keys)"};
    
    public void Next()
    {
        if (page + 1 == TutorialTexts.Length)
            this.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        }
        if (page + 1 < TutorialTexts.Length){
            page = page + 1;
            TutorialText.text = TutorialTexts[page];
        }
        if (page + 1 == TutorialTexts.Length)
        {
            NextButton.text = "Done";
        }
    }

    public void Previous()
    {
        if (page >= 0)
        {
            page = page - 1;
            TutorialText.text = TutorialTexts[page];
        }
        if (page + 1 != TutorialTexts.Length)
        {
            NextButton.text = "Next";
        }
    }

}
