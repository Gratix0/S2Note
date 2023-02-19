using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Newtonsoft.Json;

namespace Note
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text != "" && NameNoteBox.Text != "")
            {
                var des = JsonSer.Des();
                List<string> names = new List<string>();

                if (des.Count != 0 && des.ContainsKey(datePicker1.SelectedDate.ToString()))
                {
                    foreach (Note name in des[datePicker1.SelectedDate.ToString()])
                    {
                        names.Add(name.name);
                    }
                    if (des.ContainsKey(datePicker1.SelectedDate.ToString()) && !names.Contains(NameZamBox.Text))
                    {
                        Note newNote = new Note();
                        newNote.descrption = DescriptionBox.Text;
                        newNote.name = NameZamBox.Text;
                        newNote.dateTime = datePicker1.SelectedDate.ToString();
                        des[datePicker1.SelectedDate.ToString()].Add(newNote);
                        JsonSer.Ser(des);

                    }
                }
                else if (des.Count == 0 || !des.ContainsKey(datePicker1.SelectedDate.ToString()))
                {
                    Note newNote = new Note();
                    newNote.descrption = DescriptionBox.Text;
                    newNote.name = NameZamBox.Text;
                    newNote.dateTime = datePicker1.SelectedDate.ToString();

                    List<Note> newDate = new List<Note>();
                    newDate.Add(newNote);
                    des.Add(newNote.dateTime, newDate);
                    JsonSer.Ser(des);
                }
                Zametki.ItemsSource = des[datePicker1.SelectedDate.ToString()];
                DescriptionBox.Text = "";
                NameZamBox.Text = "";

                var des1 = JsonSer.Des();

                if (des1 != null)
                {
                    if (des.Keys.Contains(datePicker1.SelectedDate.ToString()))
                    {
                        List<Note> next = des1[datePicker1.SelectedDate.ToString()];
                        List<string> names1 = new List<string>();

                        foreach (Note n in next)
                        {
                            names1.Add(n.name);
                        }

                        Zametki.ItemsSource = names1;
                    }
                }
            }
    }
}
