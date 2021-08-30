using System;
namespace ShellModels.Enums
{
    /// <summary>
    /// Represents the 'Data Type' options from csv flat files
    /// </summary>
    public enum EnergyDataTypeEnum
    {
        
        ImportWhTotal,
        ExportWhTotal,
        ImportVarhTotal,
        ExportVarhTotal,

        //LP_2146...
        PhaseAngleA,
        PhaseAngleB,
        PhaseAngleC,

        VoltagePhaseAMin,
        VoltagePhaseAMax,
        VoltagePhaseBMin,
        VoltagePhaseBMax,
        VoltagePhaseCMin,
        VoltagePhaseCMax,

        CurrentPhaseAMin,
        CurrentPhaseAMax,
        CurrentPhaseBMin,
        CurrentPhaseBMax,
        CurrentPhaseCMin,
        CurrentPhaseCMax,

        ReactivePowerTotalVars,
        ApprantPowerTotalVA,
        ActivePowerTotalWatts,
        CurrentTotal,
        VoltageTotal
    }

}
