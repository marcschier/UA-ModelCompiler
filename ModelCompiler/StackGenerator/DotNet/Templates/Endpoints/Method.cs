class Placeholder
{
// ***START***
#region _NAME_ Service
#if (!OPCUA_EXCLUDE__NAME_)
#if (!NET_STANDARD)
/// <summary>
/// Invokes the _NAME_ service.
/// </summary>
public IServiceResponse _NAME_(IServiceRequest incoming)
{
    _NAME_Response response = null;

    try
    {
        OnRequestReceived(incoming);

        _NAME_Request request = (_NAME_Request)incoming;

        // DeclareResponseParameters

        response = new _NAME_Response();

        InvokeService();

        // SetResponseParameters
    }
    finally
    {
        OnResponseSent(response);
    }

    return response;
}

#else
/// <summary>
/// Asynchronously invokes the _NAME_ service - uses the async server interface if the server supports it.
/// </summary>
public async System.Threading.Tasks.Task<IServiceResponse> _NAME_(IServiceRequest incoming)
{
    _NAME_Response response = null;

    try
    {
        OnRequestReceived(incoming);

        _NAME_Request request = (_NAME_Request)incoming;

        if (ServerInstanceAsync != null)
        {
            response = new _NAME_Response();
            
            InvokeServiceAsync();
        }
        else
        {
            response = await System.Threading.Tasks.Task.Run( () => 
            {
                response = new _NAME_Response();
            
                // DeclareResponseParameters

                InvokeService();

                // SetResponseParameters

                return response;

            } 
            ).ConfigureAwait(false);
        }
    }
    finally
    {
        OnResponseSent(response);
    }
    return response;
}
#endif

#if (OPCUA_USE_SYNCHRONOUS_ENDPOINTS)
/// <summary>
/// The operation contract for the _NAME_ service.
/// </summary>
public virtual _NAME_ResponseMessage _NAME_(_NAME_Message request)
{
    _NAME_Response response = null;

    try
    {
        // check for bad data.
        if (message == null) throw new ArgumentNullException("message");

        // OnRequestReceived(message._NAME_Request);

        SetRequestContext(RequestEncoding.Xml);
        response = (_NAME_Response)_NAME_(request._NAME_Request);

        // OnResponseSent(response);
        return new _NAME_ResponseMessage(response);
    }
    catch (Exception e)
    {
        Exception fault = CreateSoapFault(request._NAME_Request, e);
        // OnResponseFaultSent(fault);
        throw fault;
    }
}
#endif

#if (NET_STANDARD)
/// <summary>
/// Asynchronously calls the _NAME_ service.
/// </summary>
public async System.Threading.Tasks.Task<_NAME_ResponseMessage> _NAME_Async(_NAME_Message message)
{
    _NAME_Response response = null;

    try
    {
        // check for bad data.
        if (message == null) throw new ArgumentNullException("message");

        OnRequestReceived(message._NAME_Request);

        // set the request context.
        SetRequestContext(RequestEncoding.Xml);

        response = (_NAME_Response)await ProcessRequestAsync(
            SecureChannelContext.Current, 
            message._NAME_Request).ConfigureAwait(false);

        OnResponseSent(response);

        return new _NAME_ResponseMessage(response);
    }
    catch (Exception e)
    {
        Exception fault = CreateSoapFault(message._NAME_Request, e);
        OnResponseFaultSent(fault);
        throw fault;
    }
}
#endif

/// <summary>
/// Asynchronously calls the _NAME_ service.
/// </summary>
public virtual IAsyncResult Begin_NAME_(_NAME_Message message, AsyncCallback callback, object callbackData)
{
    try
    {
        // check for bad data.
        if (message == null) throw new ArgumentNullException("message");

        OnRequestReceived(message._NAME_Request);

        // set the request context.
        SetRequestContext(RequestEncoding.Xml);

        // create handler.
        ProcessRequestAsyncResult result = new ProcessRequestAsyncResult(this, callback, callbackData, 0);
        return result.BeginProcessRequest(SecureChannelContext.Current, message._NAME_Request);
    }
    catch (Exception e)
    {
        Exception fault = CreateSoapFault(message._NAME_Request, e);
        OnResponseFaultSent(fault);
        throw fault;
    }
}

/// <summary>
/// Waits for an asynchronous call to the _NAME_ service to complete.
/// </summary>
public virtual _NAME_ResponseMessage End_NAME_(IAsyncResult ar)
{
    try
    {
        IServiceResponse response = ProcessRequestAsyncResult.WaitForComplete(ar, true);
        OnResponseSent(response);
        return new _NAME_ResponseMessage((_NAME_Response)response);
    }
    catch (Exception e)
    {
        Exception fault = CreateSoapFault(ProcessRequestAsyncResult.GetRequest(ar), e);
        OnResponseFaultSent(fault);
        throw fault;
    }
}
#endif
#endregion
// ***END***
}
