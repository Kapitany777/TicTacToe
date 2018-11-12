using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Különféle Message boxokat tartalmazó statikus osztály
    /// </summary>
    public static class MessageBoxGame
    {
        /// <summary>
        /// Hibaüzenet küldése
        /// </summary>
        /// <param name="text">A hibaüzenet szövege</param>
        public static void MsgError(string text)
        {
            MessageBox.Show(text, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Figyelmeztető üzenet küldése
        /// </summary>
        /// <param name="text">A figyelmeztető üzenet szövege</param>
        public static void MsgWarning(string text)
        {
            MessageBox.Show(text, "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Információs üzenet küldése
        /// </summary>
        /// <param name="text">Az információs üzenet szövege</param>
        public static void MsgInfo(string text)
        {
            MessageBox.Show(text, "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
