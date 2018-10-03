using Umbraco.Core.ObjectResolution;

public class MobileDetectorResolver : SingleObjectResolverBase<MobileDetectorResolver, IMobileDetector>
{
    public void SetMobileDetector(IMobileDetector mobileDetector)
    {       
        Value = mobileDetector;
    }

   
    public IMobileDetector MobileDetector
    {
        get { return Value; }
    }
}
