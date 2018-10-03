using System.Web;

public class AlwaysMobileDetector : IMobileDetector
{
    public bool IsMobileRequest(HttpRequest currentRequest)
    {
        return true;

    }
}