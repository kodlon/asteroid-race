using System.Collections;
using UnityEngine;


public class SizeBonus : MonoBehaviour, IBonuses
{
    public IEnumerator BonusCorutine(SpriteRenderer gunDrone, Animator bonusPanel, Transform playerTransform)
    {
        bonusPanel.SetInteger("ChangeAnim", 4);

        playerTransform.localScale /= 1.5f;

        yield return new WaitForSeconds(8);
        bonusPanel.SetInteger("ChangeAnim", 6);
        yield return new WaitForSeconds(2);

        playerTransform.localScale = Vector3.one;
        Player.BonusActive = false;
        bonusPanel.SetInteger("ChangeAnim", 0);
    }
}
