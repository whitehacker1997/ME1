namespace OnApp.DataLayer.Repository
{
    public enum  UserLogAction
    {
        ValidatePassword,
        IncorrectPasswordEntered,
        LoginByPassword,
        Logout,
        RestorePassword,
        RestoredPassword,
        LoginBySms
    }
}
