namespace LabTwo.ViewInteractors.Cleaners
{
    public static class ViewCleaner
    {
        public static void CleanTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
                textBox.Text = string.Empty;
        }
        public static void CleanComboBoxes(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
                comboBox.SelectedIndex = -1;
        }
    }
}