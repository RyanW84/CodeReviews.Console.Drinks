using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleTableExt;

namespace Drinks.RyanW84;

public class TableVisualisationEngine
    {
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class 
    {
    Console.Clear();

        if (tableName is null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder.From(tableData).WithColumn(tableName).ExportAndWriteLine();
        Console.WriteLine("\n\n");
    }
    }
