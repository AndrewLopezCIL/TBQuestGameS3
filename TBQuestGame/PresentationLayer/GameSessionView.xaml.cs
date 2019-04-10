using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.PresentationLayer;
using TBQuestGame.DataLayer;
namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {

        GameSessionViewModel _gameSessionViewModel;
        
        private string Messages; 
        private double PlayerHealth;
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
           // ActiveEnemies.Items.Add("Testing");
            InitializeComponent();
            Messages = _gameSessionViewModel.Messages;
            PlayerHealth = _gameSessionViewModel.PlayerHealth;
        }

        private void GameOptions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SkillsButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = new ListBoxItem();
            StackPanel new_item = new StackPanel();
            new_item.Orientation = Orientation.Horizontal;
            Image img = new Image();
            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();
            bitImage.UriSource = new Uri("/Images/warrior-icon.png", UriKind.Relative);
            bitImage.EndInit();
            img.Source = bitImage;
            img.Width = 32;
            img.Height = 32;

            TextBlock entityLevel = new TextBlock();
            entityLevel.Text = "{LVL 55}";
            entityLevel.FontWeight = FontWeights.Bold;
            entityLevel.FontSize = 16;
            entityLevel.VerticalAlignment = VerticalAlignment.Center;

            TextBlock entityName = new TextBlock();
            entityName.Text = "Warrior";
            entityName.FontSize = 15.5;
            entityName.FontWeight = FontWeights.Bold;
            entityName.VerticalAlignment = VerticalAlignment.Center;
            
            new_item.Children.Add(img);
            new_item.Children.Add(entityLevel);
            new_item.Children.Add(entityName);
            item.Content = new_item;
            item.Background = Brushes.Red;
            item.BorderBrush = Brushes.Black;
            item.BorderThickness = new Thickness(3,3,3,0);
            
            ActiveEnemies.Items.Add(item);
        }  
        private static void AddEnemyToList()
        {

        }
          private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerHealth -= 5;
            playerHealthBar.Value = PlayerHealth;
        }
    }
}
