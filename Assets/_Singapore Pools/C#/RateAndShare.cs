using UnityEngine;

public class RateAndShare : MonoBehaviour
{

    public void RateButton()
    {
        Sound_Manager.instance.Btn_Click_Clip();

#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
#elif UNITY_IOS
        UnityEngine.iOS.Device.RequestStoreReview();
#endif
    }



    public void ShareButton()
    {
        Sound_Manager.instance.Btn_Click_Clip();

        new NativeShare().SetSubject("Share It").SetText("Share app & support us").Share();    // Download & Import Native Share Package from Assets Store
    }


}   // Class End
