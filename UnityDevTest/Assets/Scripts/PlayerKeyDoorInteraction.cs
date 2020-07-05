using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyDoorInteraction : MonoBehaviour
{
    

    private List<Key.KeyType> keyList;

    private void Awake(){
        keyList = new List<Key.KeyType>();
    }


    public void AddKey(Key.KeyType keyType){
        keyList.Add(keyType);
    }
    public void RemoveKey(Key.KeyType keyType){
        keyList.Remove(keyType);
    }
    public bool ConatinsKey(Key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if(key != null){
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
        Door door = collider.GetComponent<Door>();
        if(door != null){
            if(ConatinsKey(door.GetKeyType())){
                //we have the key!
                door.open();
                RemoveKey(door.GetKeyType());
            } 
        }

    }
}
