using EXAM_wpf_0._3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_wpf_0._3.Servises
{
    internal class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            return null;
        }
        
        public void SavedData(BindingList<TodoModel> todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);  //десериализируем todoDataList с помощью конвертора json в строку
                writer.Write(output);                                       //записываем эту строку в файл
            }
        }
    }
}
