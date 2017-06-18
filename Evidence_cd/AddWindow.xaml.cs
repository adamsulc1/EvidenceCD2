using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Evidence_cd
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();
            item.Album = addAlbum.Text;
            item.Artist = addArtist.Text;
            item.Genre = addGenre.Text;
            item.Year = Convert.ToInt64(addYear.Text);
            item.Price = Convert.ToInt64(addPrice.Text);
            App.Database.SaveItemAsync(item);
            echo.Text = "Item added.";
        }
    }
}
