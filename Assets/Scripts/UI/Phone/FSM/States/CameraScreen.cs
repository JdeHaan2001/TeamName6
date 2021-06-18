using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraScreen : PhoneScreenWithView<CameraView>
{
    public override void EnterScreen()
    {
        base.EnterScreen();

        phoneView.PrevPicBtn.onClick.AddListener(_PFSM.ChangeScreen<GalleryScreen>);
        //phoneView.TakePicBtn.onClick.AddListener(Screenshot.TakeScreenShot);
        phoneView.TakePicBtn.onClick.AddListener(takePicture);
    }

    private void takePicture()
    {
        ScreenCapture.CaptureScreenshot("ScreenShots/Screenshot.png");
    }
}
