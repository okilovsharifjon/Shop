namespace OsonCommerce.Infrastructure.Authentication;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int ExpireHours { get; set; }
}
