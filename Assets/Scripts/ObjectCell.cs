using Exoa.Events;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCell : MonoBehaviour
{
    private ObjectsData _objectsData;
    private Button _button;
    [SerializeField] public Toggle SelectToggle;
    [SerializeField] public Toggle HiddenToggle;
    [SerializeField] private GameObject _cellObject;
    public void Init(GameObject @object, ObjectsData objectsData)
    {
        _cellObject = @object;
        _objectsData = objectsData;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(FocusObject);
        SelectToggle.onValueChanged.AddListener(SelectObject);
        HiddenToggle.onValueChanged.AddListener(HiddenObject);
    }
    public void SelectObject(bool isOn)
    {
        if (isOn == true)
        {
            _objectsData.SelectObject(_cellObject);
            _button.Select();
        }
        else
        {
            _objectsData.RemoveSelectObject(_cellObject);
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
        CameraEvents.OnRequestObjectFocus?.Invoke(_cellObject, true);
    }
} 
