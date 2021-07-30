using System.Collections;
using UnityEngine;


public class SizeBonus : MonoBehaviour, IBonuses
{
    public IEnumerator BonusCorutine(GameObject playerObject, SpriteRenderer gunDrone, Animator bonusPanel, SpriteRenderer playerSprite)
    {
        bonusPanel.SetInteger("ChangeAnim", 4);

        playerObject.transform.localScale /= 1.5f;

        yield return new WaitForSeconds(8);
        bonusPanel.SetInteger("ChangeAnim", 6);
        yield return new WaitForSeconds(2);

        playerObject.transform.localScale = Vector3.one;
        Player.BonusActive = false;
        bonusPanel.SetInteger("ChangeAnim", 0);

        yield break;
    }

}
