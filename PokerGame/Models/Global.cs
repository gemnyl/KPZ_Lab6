using PokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace PokerGame.Models
{
    internal class Global
    {
        public static Player MyPlayer { get; set; }
        public static int Difficulty { get; set; }
        public static int EndScore { get; set; }
        public static string EndHand { get; set; }
        public static string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\Design Patterns\KPZ_Lab6\PokerGame\Data\FiveDrawDB.mdf;Integrated Security=True";

        public static ObservableCollection<CardView> FinalHand { get; set; }

        // Різноманітні методи виклику звуків
        public static void PlayDrawCardSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Swoosh1);
            player.Play();
        }

        public static void PlayDragAndDropSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.DragAndDrop1);
            player.Play();
        }

        public static void PlayClickSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Click);
            player.Play();
        }

        public static void PlayNoPointsSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.NoPoints);
            player.Play();
        }

        public static void PlayPointsSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Points);
            player.Play();
        }

        public static void PlayHighScoreSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.HighScore);
            player.Play();
        }
    }
}
