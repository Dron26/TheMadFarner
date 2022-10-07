using System.IO;
using UnityEngine;

public class GameInitializator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private LogoUiController _logoUiController;
    [SerializeField] private HarvesterHealth _harvesterHealth;
    [SerializeField] private Save _save;

    private string filePath;

    private void Start()
    {
        _sceneChanger.FirstStart();
        _player.SetEnterGame(true);

        var directory = Application.persistentDataPath + "/saves";  
        filePath = directory + "/GameSave.save";

        if (!File.Exists(filePath))
        {
            Initialize();
            SetFirstStart();
        }
        else
        {
            _save.SetSecondStart();
        }
    }

    private void InitializePlayer()
    {        
        string nameAvatar = "Player";
        _player.Initialization(nameAvatar);
    }


    private void InitializeWallet()
    {
        int amountMoney = 5;
        int maxAmountMoney = 1000;
        _wallet.Initialization(amountMoney, maxAmountMoney);
    }

    private void Initialize()
    {
        InitializePlayer();
        InitializeWallet();
    }

    private void SetFirstStart()
    {   
        _logoUiController.FirstStart();    
    }
}
