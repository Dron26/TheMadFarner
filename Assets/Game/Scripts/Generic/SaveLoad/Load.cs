using UnityEngine;
using UnityEngine.Events;

public class Load : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private FieldSelecterStatus _fieldSelecterStatus;
    [SerializeField] private SpawnerPlant _spawnerPlant;
    [SerializeField] private Harvester _harvester;

    private Storage _storage;
    private GameData _gameData;

    private bool _isFirstStart;
    private bool _isHomeSceneStart;
    private bool _isFieldSceneStart;

    public UnityAction LoadParameter;

    public void LoadData()
    {
        _storage = new Storage();
        _gameData = (GameData)_storage.Load(new GameData());
        _player.LoadParametr(_gameData.ImageName);
        _wallet.LoadParametr(_gameData.Money, _gameData.MaxMoney);
        _harvester.LoadParametr(_gameData.CountReelsKilledZombi);

        if (_isFieldSceneStart == true)
        {
            SetParametrsFieldStart();
        }

        LoadParameter?.Invoke();
    }

    public void StartHomeScene()
    {
        _isHomeSceneStart = true;
    }

    public void StartFieldScene()
    {
        _isFieldSceneStart = true;
    }

    private void SetParametrsFirstStart()
    {
        _player.SetEnterGame(false);
    }

    private void SetParametrsFieldStart()
    {
        _spawnerPlant.LoadParametr(_gameData.NumberSelectField);
    }
}
