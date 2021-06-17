using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    private static Screenshot _instance = null;

    private Camera _cam = null;

    private bool _canTakeScreenshot;

    private void Awake()
    {
        _instance = this;
        _cam = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (_canTakeScreenshot)
        {
            _canTakeScreenshot = false;

            RenderTexture renderTexture = _cam.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Picture.png", byteArray);
            Debug.Log("Saved Picture.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            _cam.targetTexture = null;
        }
    }

    private void takeScreenShot(int pWidth, int pHeight)
    {
        _cam.targetTexture = RenderTexture.GetTemporary(pWidth, pHeight, 16);
        _canTakeScreenshot = true;
    }

    public static void TakeScreenShot()
    {
        _instance.takeScreenShot(Screen.width, Screen.height);
    }
}
