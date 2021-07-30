using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ArmorBonus : MonoBehaviour, IBonuses
{
    public IEnumerator BonusCorutine(GameObject playerObject, SpriteRenderer gunDrone, Animator bonusPanel, SpriteRenderer playerSprite)
    {
        playerObject.GetComponent<Player>().Health++;
        playerSprite.color = new Color(1f, 0.1686275f, 0.1686275f, 1.0f);
        bonusPanel.SetInteger("ChangeAnim", 1);

        yield break;
    }
}
