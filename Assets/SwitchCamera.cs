using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SwitchCamera : MonoBehaviour
{
    public List<Camera> Cameras;
    private VisualElement frame;
    private Button button;

    int click = 0;
    
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        button = frame.Q<Button>("Button");
        button.RegisterCallback<ClickEvent>(ev => ChangeCamera());
    }
    private void ChangeCamera()
    {
        Debug.Log("click");
        EnableCamera(click);
        click++;
        if (click > Cameras.Count - 1)
        {
            click = 0;
        }
    }
    private void EnableCamera(int n)
    {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }

}

