namespace WebApp.Strategy.Models
{
    public class Settings
    {
        public static string claimDatabaseType = "databasetype";
        public EDatabaseType databaseType;
        public EDatabaseType getDefaultDatabaseType=>EDatabaseType.SqlServer;// default olarak sql kullansın seçilirse mongodb kullansın ya da seçiniz koyabilirsin TODO:
    }
}
