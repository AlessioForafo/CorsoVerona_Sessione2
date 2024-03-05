#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.DataLogger;
using FTOptix.Store;
using FTOptix.SQLiteStore;
using FTOptix.ODBCStore;
using FTOptix.Recipe;
using FTOptix.OPCUAServer;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void LogMessaggio()
    {
        // Insert code to be executed by the method
        Log.Info("messaggio custom!");
    }

    [ExportMethod]
    public void CreaVariabili()
    {
        for (int i = 0; i < 100; i++) 
        {
            var myVar = InformationModel.MakeVariable("Var" + i, OpcUa.DataTypes.Int16);
            Project.Current.Get("Model/VariabiliCreateDaCodice").Add(myVar);
        }
    }

}
