using Nancy;

public class SimpleModule : NancyModule
{
    public SimpleModule()
    {
        Get["/"] = p => { return HttpStatusCode.OK; };
    }
}