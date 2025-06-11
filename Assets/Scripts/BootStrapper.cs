using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private AlfaButtons alfaButtons;
    [SerializeField] private ObjectCellsSettings cellsSettings;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _minusButton;
    [SerializeField] private Button _plusButton;
    [SerializeField] private Button _restartButton;

    [SerializeField] private Text _pathText;
    [SerializeField] private Text _numberText;
    [SerializeField] private Image _panelObjects;
    [SerializeField] private Image _startPanel;


    private Object[] _objects;
    private void Start()
    {

        _minusButton.onClick.AddListener(MinusObject);
        _plusButton.onClick.AddListener(PlusObject);
        _startButton.onClick.AddListener(StartApp);
        _saveButton.onClick.AddListener(Save);
        _loadButton.onClick.AddListener(Load);
        _restartButton.onClick.AddListener(Restart);

        List<Object> objects = new List<Object>();
        foreach (Transform child in S_ObjectsSettings.Instance.transform)
        {
            if (child.GetComponent<Object>())
            {
                objects.Add(child.GetComponent<Object>());
            }
        }
        _objects = objects.ToArray();
        _numberText.text = NumberObject().ToString();
    }
    private void MinusObject()
    {
        if (NumberObject() > 0)
        {
            _objects[NumberObject() - 1].gameObject.SetActive(false);
            _numberText.text = NumberObject().ToString();
        }
    }
    private void PlusObject()
    {
        if (NumberObject() < _objects.Length)
        {
            _objects[NumberObject()].gameObject.SetActive(true);
            _numberText.text = NumberObject().ToString();
        }
    }
    public int NumberObject()
    {
        int number = 0;
        for (int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i].gameObject.activeSelf)
            {
                number++;
                number = Mathf.Clamp(number, 1, _objects.Length);
            }
        }
        return number;
    }
    private void StartApp()
    {
        S_ObjectsSettings.Instance.Init(cellsSettings);
        alfaButtons.Init();
        cellsSettings.Init();
        _panelObjects.gameObject.SetActive(true);
        _startPanel.gameObject.SetActive(false);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
    #region SaveLoad
    private void Save()
    {
        SaveLoadFromJSON.RemoveData();
        for (int i = 0; i < S_ObjectsSettings.Instance.GetListObjects().Count; i++)
        {
            SaveLoadFromJSON.SaveObject(S_ObjectsSettings.Instance.GetObject(i).GetData());
        }
        SaveLoadFromJSON.SaveInJSON();
        _pathText.text = "Сохранено в " + Application.persistentDataPath + "/save.json";
    }
    private void Load()
    {
        List<ObjectDataItem> items = SaveLoadFromJSON.LoadObjectsFromJSON();
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < items.Count; i++)
        {
            _objects[i].gameObject.SetActive(true);
            _objects[i].SetData(items[i].Alfa, items[i].Active);
        }
        StartApp();
    }
    #endregion
}
