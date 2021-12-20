using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Helpers
{
    public static class UIHelpers
    {
        public static void ChangeWidthGridColumns(ColumnDefinition column, double stars)
        {
                column.Width = new GridLength(stars, GridUnitType.Star);
        }
    }
}