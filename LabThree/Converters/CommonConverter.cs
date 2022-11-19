namespace LabThree.Converters
{
    public static class CommonConverter
    {
        public static bool ToBoolValue(string strValue)
        {
            if (strValue == "true")
                return true;
            else
                return false;
        }
    }
}