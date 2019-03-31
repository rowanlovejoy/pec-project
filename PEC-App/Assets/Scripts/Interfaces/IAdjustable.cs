using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface used by environmental models
/// </summary>
interface IAdjustable
{
    /// <summary>
    /// Checks the current tick and updates the model based on the selection settings accordingly.
    /// </summary>
    void AdjustVariables(int _currentTick);

    /// <summary>
    /// Resets simulation variables to default values
    /// </summary>
    void ResetVariables();
}
