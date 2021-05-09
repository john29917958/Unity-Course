using UnityEngine;

public class RoomList : MonoBehaviour
{
    [SerializeField]
    private Room _roomPrefab;

    [SerializeField]
    private GameObject _contentArea;

    public void AddRoom(string name, int playerCount, int maxPlayers, bool isOpen)
    {
        Room room = Instantiate(_roomPrefab, _contentArea.transform);
        room.Description.text = name + " (" + playerCount + '/' + maxPlayers + ") - " + (isOpen ? "Available" : "Unavailable");
        room.RoomName = name;        
        room.PlayerCount = playerCount;
        room.MaxPlayerCount = maxPlayers;
        room.IsOpen = isOpen;
    }

    public void Clear()
    {
        foreach (Transform child in _contentArea.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
