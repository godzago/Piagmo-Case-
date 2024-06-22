using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScorUpdate : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] Image coinSprite;
    [SerializeField] Image newCoinSprite;

    private int updateFullScore = 30 ;
    private int updateFullDamage = 100;

    public void updateScor(int updateText)
    {
        scoreText.text = updateFullScore + " / " + updateText.ToString();
    }
    public void updateDamege(float updateTextt)
    {
        damageText.text = updateFullDamage + " / " + updateTextt.ToString();
    }

    public void coinSpriteUpdate()
    {
        coinSprite.sprite = newCoinSprite.sprite;
    }
}
