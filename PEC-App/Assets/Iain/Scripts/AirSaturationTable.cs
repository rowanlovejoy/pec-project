using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSaturationTable
{
    private Dictionary<int, Dictionary<int, int>> m_wallSaturationDictionary;

    public AirSaturationTable()
    {
        Dictionary<int, int> firstRow = new Dictionary<int, int>()
        {
            [1] = 50,
            [2] = 70,
            [3] = 100,
            [4] = 100,
            [5] = 100
        };

        Dictionary<int, int> secondRow = new Dictionary<int, int>()
        {
            [1] = 50,
            [2] = 70,
            [3] = 90,
            [4] = 100,
            [5] = 100
        };

        Dictionary<int, int> thirdRow = new Dictionary<int, int>()
        {
            [1] = 50,
            [2] = 60,
            [3] = 80,
            [4] = 100,
            [5] = 100
        };

        Dictionary<int, int> fourthRow = new Dictionary<int, int>()
        {
            [1] = 50,
            [2] = 50,
            [3] = 70,
            [4] = 90,
            [5] = 100
        };

        Dictionary<int, int> fifthRow = new Dictionary<int, int>()
        {
            [1] = 50,
            [2] = 50,
            [3] = 70,
            [4] = 80,
            [5] = 100
        };

        m_wallSaturationDictionary = new Dictionary<int, Dictionary<int, int>>()
        {
            [14] = firstRow,
            [16] = secondRow,
            [18] = thirdRow,
            [20] = fourthRow,
            [22] = fifthRow
        };
    }

    public int GetValue(int temperature, int moistureInLitres)
    {
        return m_wallSaturationDictionary[temperature][moistureInLitres];
    }
}
