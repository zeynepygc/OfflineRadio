using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using OfflineRadio.Models;

namespace OfflineRadio.DataAccess
{
    public static class FileManager
    {
        private const string ProgramFilePath = "programs.json";

        public static BindingList<RadioProgram> LoadPrograms()
        {
            if (File.Exists(ProgramFilePath))
            {
                string json = File.ReadAllText(ProgramFilePath);
                return JsonSerializer.Deserialize<BindingList<RadioProgram>>(json) ?? new BindingList<RadioProgram>();
            }

            return new BindingList<RadioProgram>();
        }

        public static void SavePrograms(BindingList<RadioProgram> programs)
        {
            string json = JsonSerializer.Serialize(programs);
            File.WriteAllText(ProgramFilePath, json);
        }
    }
}
