using System.Web;

public class AspNetMobileDetector : IMobileDetector
{
    public bool IsMobileRequest(HttpRequest currentRequest)
    {
        return currentRequest.Browser.IsMobileDevice;
    }
}