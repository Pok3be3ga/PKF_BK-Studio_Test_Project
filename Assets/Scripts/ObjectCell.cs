using Exoa.Events;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCell : MonoBehaviour
{
    private Button _button;
    [SerializeField] public Toggle SelectToggle;
    [SerializeField] public Toggle HiddenToggle;
    [SerializeField] private Object _cellObject;
    public void Init(Object @object)
    {
        _cellObject = @object;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(FocusObject);
        SelectToggle.onValueChanged.AddListener(SelectObject);
        HiddenToggle.onValueChanged.AddListener(HiddenObject);
    }
    public void SelectObject(bool isOn)
    {
        if (isOn == true)
        {
            S_ObjectsSettings.Instance.SelectObject(_cellObject);
            _button.Select();
        }
        else
        {
            S_ObjectsSettings.Instance.RemoveSelectObject(_cellObject);
        }
    }
    public void HiddenObject(bool isOn)
    {
        _cellObject.GetComponent<MeshRenderer>().enabled = isOn;
    }
    public void HightLightCell()
    {
        _button.Select();
    }
    private void FocusObject()
    {
        CameraEvents.OnRequestObjectFocus?.Invoke(_cellObject.gameObject, true);
    }
} 
