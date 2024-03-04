using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo {
    public static int GetTime(int gameNum) {
        switch (gameNum) {
            case 1:
                return 5;
            case 2:
                return 10;
            case 3:
                return 4;
            case 4:
                return 10;
            case 5:
                return 5;
            default:
                return 10;
        }
    }
}
