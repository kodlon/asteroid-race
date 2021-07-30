using System.Collections;
using UnityEngine;

public class TimeBonus : MonoBehaviour, IBonuses
{
    public IEnumerator BonusCorutine(GameObject playerObject, SpriteRenderer gunDrone, Animator bonusPanel, SpriteRenderer playerSprite)
    {
        bonusPanel.SetInteger("ChangeAnim", 3);

        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(3);

        bonusPanel.SetInteger("ChangeAnim", 5);
        yield return new WaitForSeconds(2);
        bonusPanel.speed = 1f;

        Time.timeScale = 1.0f;
        Player.BonusActive = false;
        bonusPanel.SetInteger("ChangeAnim", 0);

        yield break;
    }
}
