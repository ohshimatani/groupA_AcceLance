using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCell : MonoBehaviour
{
    // Š¿š‚Ìî•ñi“Ç‚İæ‚èê—pj
    public KanjiInfo kanjiInfo { get; private set; }

    public void InitKanjiStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
    }
}
