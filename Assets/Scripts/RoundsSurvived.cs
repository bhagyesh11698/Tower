using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        //roundsText.text = PlayerStats.Rounds.ToString();
        StartCoroutine(AnimateText());

    } // called everytime a game object is enabled

    IEnumerator AnimateText()
    {

        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);


        while (round < 3) // 3 or playerprefs.rounds *
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
