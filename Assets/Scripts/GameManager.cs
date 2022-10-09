using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private GameManager()
    {

    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    private bool contact = false;

    public bool Contact()
    {
        return contact;
    }

    public void SetContact(bool contact)
    {
        this.contact = contact;
    }
}

