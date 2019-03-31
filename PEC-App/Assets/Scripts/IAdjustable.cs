using System.Collections;
using System.Collections.Generic;

interface IAdjustable
{
    /// <summary>
    /// Checks the current tick and updates the model based on the selection settings accordingly.
    /// </summary>
    void AdjustVariables(int currentTick);

}
