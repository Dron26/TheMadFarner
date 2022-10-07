using UnityEngine;

public class Save : MonoBehaviour
{
    private Storage _storage;
    private GameData _gameData;

    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private FieldSelecterStatus _fieldSelecterStatus ;
    [SerializeField] private Harvester _harvester;

    private bool _isFieldSceneExit;
    private bool _isHomeSceneExit;
    private bool _isLogoSceneExit;
    private bool _isSecondStart;

    public void SaveData()
    {
        _storage = new Storage();
        _gameData = new GameData();
        _gameData.FirstUpdateDate(_player, _wallet, _harvester);
            
        if (_fieldSelecterStatus != null)
        {
            _gameData.HomeUpdateDate(_fieldSelecterStatus);
        }
         
        if (_isSecondStart==false)
        {
            _storage.Save(_gameData);
        }    
    }

    public void ExitHomeScene()
    {
        _isHomeSceneExit = true;
    }

    public void ExitFieldScene()
    {
        _isFieldSceneExit = true;
    }

    public void SetSecondStart()
    {
        _isSecondStart = true;
    }
}
