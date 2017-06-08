using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedImport.DataClass.State
{
    interface IImportProcessConfig
    {
        bool ImportStatusOk { get; }

        ImportStagesEnum Stage { get; set; }

        Tebaldi.MarketData.Models.State.FeedState Feed { get; }

        string DownloadFileSaveName { get; }

        string DownloadPath { get; }
    }


    public enum ImportStagesEnum
    {
        InitialStage,
        FileDonloadStarted,
        FileDonloadEnded,
        FileProcessingStarted,
        FileProcessingEnded,
        SaveDataStarted,
        SaveDataEnded,
        FinalStage,
        Error
    }
}
