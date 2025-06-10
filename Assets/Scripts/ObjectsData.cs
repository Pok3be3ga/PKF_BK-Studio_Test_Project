using System.Collections.Generic;
using Exoa.Cameras.Demos;
using UnityEngine;

public class ObjectsData : MonoBehaviour
{
    private ObjectCellsSettings _objectCellsSettings;
    private List<GameObject> _objects = new List<GameObject>();//��� ������� ������� ���� �� �����
    private List<GameObject> _selectObjects = new List<GameObject>();//������� ��������� �������������
    public void Init(ObjectCellsSettings objectCellsSettings)
    {
        //��������� �������� ������� � ������
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                _objects.Add(child.gameObject);
                child.GetComponent<FocusOnClick>().Init(this);
            }
        }
        _objectCellsSettings = objectCellsSettings;
    }


    //������� �� �����
    public List<GameObject> GetListObjects()
    {
        return _objects;
    }
    public GameObject GetObject(int index)
    {
        return _objects[index];
    }
    //��������� �������
    public void SelectObject(GameObject go)
    {

        if (_selectObjects.Contains(go))
        {

        }
        else
        {
            _selectObjects.Add(go);
        }
    } 
    public void HightLightCell(GameObject go)
    {
        int index = _objects.IndexOf(go);
        _objectCellsSettings.HightLightCell(index);
    }
    public void RemoveSelectObject(GameObject go)
    {
        _selectObjects.Remove(go);
    }
    public List<GameObject> GetSelectObjects()
    {
        return _selectObjects;
    }
}
