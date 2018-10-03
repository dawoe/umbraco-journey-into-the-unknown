
using System.Web;

public interface IMobileDetector
{
    bool IsMobileRequest(HttpRequest currentRequest);
}