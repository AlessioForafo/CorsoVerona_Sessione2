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

public class RuntimeNetLogic1 : BaseNetLogic
{
    private PeriodicTask myPeriodicTask;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("Start progetto");
        myPeriodicTask = new PeriodicTask(IncrementVariable, 1000, LogicObject);
        myPeriodicTask.Start();
    }

    private void IncrementVariable()
    {
        var var0 = Project.Current.GetVariable("Model/VariabiliCreateDaCodice/Var0");
        var0.Value = var0.Value + 1;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("Stop progetto");
        myPeriodicTask.Dispose();
    }

    [ExportMethod]
    public void ScriviMessaggioCustom(string testoMessaggio)
    {
        Log.Info(testoMessaggio);
        var operazioneTreminata = LogicObject.GetVariable("OperazioneTerminata");
        operazioneTreminata.Value = true;
    }
}
