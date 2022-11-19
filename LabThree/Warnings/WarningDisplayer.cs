namespace LabTwo.Warnings
{
    public static class WarningDisplayer
    {
        public static void ShowWarning(Panel warningPanel, TextBox warningTextBox, List<IWarning> warnings)
        {
            warningTextBox.Text = string.Empty; // clear previous text if there is some
            warningTextBox.Text += "Some errors occured:\r\n\r\n";
            foreach (IWarning warning in warnings)
                warningTextBox.Text += "- " + warning.Text + "\r\n";
            warningPanel.Show();
        }
        public static void CloseWarning(Panel warningPanel, TextBox warningTextBox)
        {
            warningPanel.Hide();
            warningTextBox.Text = string.Empty;
        }
    }
}