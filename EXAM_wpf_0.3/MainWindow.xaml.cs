using EXAM_wpf_0._3.Model;
using EXAM_wpf_0._3.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EXAM_wpf_0._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TodoModel> _todoDataList;
        private FileIOService _fileIOService;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _todoDataList = _fileIOService.LoadData();  //грузим данные из файла

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();                            // после ошибки закрыть главное окно
            }

            dgTodoList.ItemsSource = _todoDataList;     //привязка данных к datagrid
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SavedData(sender);  //сохраняем данные в файл

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();                            // после ошибки закрыть главное окно
                }
            }
        }

       
    }
}

