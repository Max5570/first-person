using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    private List<IGameManager> _startSequece;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        _startSequece = new List<IGameManager>();
        _startSequece.Add(Player);
        _startSequece.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequece)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequece.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;


            foreach (IGameManager manager in _startSequece)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
                if (numReady > lastReady)
                {
                    print("Progress: " + numReady + "/" + numModules);
                    yield return null;
                }
            }
        }
        print("All managers started up");
    }
}
