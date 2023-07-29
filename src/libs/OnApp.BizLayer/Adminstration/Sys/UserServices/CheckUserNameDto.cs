namespace OnApp.BizLayer.UserServices;

public class CheckUserNameDto
{
    public int? Id { get; set; }
    public string UserName { get; set; } = null!;
} 

public class CheckUserNameRespDto
{
    public string UserName { get; set; } = null!;
    public bool IsBusy { get; set; }
}
