using UnityEngine;

public class LobbyList : MonoBehaviour
{
    [SerializeField]
    private Lobby _lobbyPrefab;

    [SerializeField]
    private GameObject _contentArea;

    public void AddLobby(string name, string type, int playerCount, int roomCount)
    {
        Lobby lobby = Instantiate(_lobbyPrefab, _contentArea.transform);
        lobby.Description.text = name + " (" + type + ") | " + playerCount + " / " + roomCount + " players";
        lobby.LobbyName = name;
    }

    public void Clear()
    { 
        foreach (Transform child in _contentArea.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
