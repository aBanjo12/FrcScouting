namespace FrcScouting;

public struct ApiRequest<T>(T parsedResponse, bool result)
{
    public T ParsedResponse = parsedResponse;
    public bool Result = result;
}