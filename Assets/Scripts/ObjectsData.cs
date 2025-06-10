using System.Collections.Generic;
using Exoa.Cameras.Demos;
using UnityEngine;

public class ObjectsData : MonoBehaviour
{
    private ObjectCellsSettings _objectCellsSettings;
    private List<GameObject> _objects = new List<GameObject>();//Все объекты которые есть на сцене
    private List<GameObject> _selectObjects = new List<GameObject>();//Объекты выбранные пользователем
    public void Init(ObjectCellsSettings objectCellsSettings)
    {
        //Добавляем дочерние объекты в список
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


    //Обьекты на сцене
    public List<GameObject> GetListObjects()
    {
        return _objects;
    }
    public GameObject GetObject(int index)
    {
        return _objects[index];
    }
    //Выбранные Объекты
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
