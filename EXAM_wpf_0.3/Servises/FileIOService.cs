using EXAM_wpf_0._3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.WebRequestMethods;

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
            var FileExists = File.Exists(PATH);  // проверка - существует ли файл
            if (!FileExists)
            {
                File.CreateText(PATH).Dispose();    //если файла нет то создаем
                return new BindingList<TodoModel>();//читать нечего возвращаем пустую колекцию
            }
            using (var reader = File.OpenText(PATH))
            {
                var filetext = reader.ReadToEnd();                                      //считываем данные в строку
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(filetext); //десериализируем в колекцию BindingList<TodoModel>
            }
        }

        public void SavedData(object todoDataList)  //object вместо BindingList<TodoModel> 
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);  //сериализируем todoDataList с помощью конвертора json в строку
                writer.Write(output);                                       //записываем эту строку в файл
            }
        }
    }
}
