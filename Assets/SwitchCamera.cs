using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SwitchCamera : MonoBehaviour
{
    public List<Camera> Cameras;
    public List<Light> Lights;
    private VisualElement frame;
    private Button button1;
    private Button button2;
    int click1 = 0;
    int click2 = 0;
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        button1 = frame.Q<Button>("Button");
        button1.RegisterCallback<ClickEvent>(ev => ChangeCamera());
        button2 = frame.Q<Button>("Light");
        button2.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }
    private void ChangeCamera()
    {
        EnableCamera(click1);
        click1++;
        if (click1 > Cameras.Count - 1)
        {
            click1 = 0;
        }
    }

    private void ChangeLight()
    {
        EnableLight(click2);
        click2++;
        if (click2 > Lights.Count - 1)
        {
            click2 = 0;
        }
    }
    private void EnableCamera(int n)
    {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }

    private void EnableLight(int n)
    {
        Lights.ForEach(lit => lit.enabled = false);
        Lights[n].enabled = true;
    }
}

