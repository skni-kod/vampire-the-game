using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//interface danych do plikow ktore chcemy zapisac


public interface ISaveable
{
    object SaveState();
    void LoadState(object state);
}
