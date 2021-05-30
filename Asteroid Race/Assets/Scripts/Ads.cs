using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

    private void Start() {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4141995", false);
        }
    }

    public static void ADS() {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
}
