using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : PhoneView
{
    [SerializeField] private Button _takePicBtn = null;
    [SerializeField] private Button _flipCambtn = null;
    [SerializeField] private Button _prevPicBtn = null;

    public Button TakePicBtn { get => _takePicBtn; }
    public Button FlipCamBtn { get => _flipCambtn; }
    public Button PrevPicBtn { get => _prevPicBtn; }
}
