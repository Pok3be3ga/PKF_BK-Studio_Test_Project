using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCellsSettings : MonoBehaviour
{
    private List<ObjectCell> _cells = new List<ObjectCell>();
    [SerializeField] private ObjectCell _cellPrefab;
    [SerializeField] private Toggle _selectAllToggle;
    [SerializeField] private Toggle _hiddenAllTogle;

    public void Init()
    {
        for (int i = 0; i < S_ObjectsSettings.Instance.GetListObjects().Count; i++)
        {
            ObjectCell cell = Instantiate(_cellPrefab, transform);
            _cells.Add(cell);
            cell.Init(S_ObjectsSettings.Instance.GetObject(i));
        }
        _selectAllToggle.onValueChanged.AddListener(SelectAll);
        _hiddenAllTogle.onValueChanged.AddListener(HiddenAll);
    }
    private void SelectAll(bool isOn)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            _cells[i].SelectToggle.isOn = isOn;
        }
    }
    private void HiddenAll(bool isOn)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            _cells[i].HiddenToggle.isOn = isOn;
        }
    }

    public void HightLightCell(int index)
    {
        _cells[index].HightLightCell();
    }
}
