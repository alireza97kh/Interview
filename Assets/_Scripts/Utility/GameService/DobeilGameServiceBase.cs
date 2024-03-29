using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DobeilGameServiceBase : MonoSingleton<DobeilGameServiceBase>
{
    public void SendRequest(string _baseUrl, SendRequestMethods method, string bodyData = "", Dictionary<string, string> headers = null, Action<HttpResponse> callback = null)
    {
        string url = _baseUrl;
        StartCoroutine(SendRequestCoroutine(url, method, bodyData, headers, callback));
    }

    private IEnumerator SendRequestCoroutine(string url, SendRequestMethods method, string bodyData = "", Dictionary<string, string> headers = null, Action<HttpResponse> callback = null)
    {
        using (UnityWebRequest request = CreateRequest(url, method, bodyData, headers))
        {
            yield return request.SendWebRequest();
            HttpResponse response = new HttpResponse(request);
            callback?.Invoke(response);
        }
    }

    private UnityWebRequest CreateRequest(string url, SendRequestMethods method, string bodyData = "", Dictionary<string, string> headers = null)
    {
        UnityWebRequest request;

        switch (method)
        {
            case SendRequestMethods.GET:
                request = UnityWebRequest.Get(url);
                break;
            case SendRequestMethods.PUT:
                request = UnityWebRequest.Put(url, bodyData);
                break;
            case SendRequestMethods.POST:
                request = UnityWebRequest.Post(url, bodyData);
                break;
            // Add more methods (PUT, DELETE, etc.) as needed.
            default:
                throw new ArgumentException("Unsupported HTTP method: " + method);
        }
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
        }

        return request;
    }

	public async Task SendRequestAsync(string _baseUrl, SendRequestMethods method, string bodyData = "", Dictionary<string, string> headers = null, Action<HttpResponse> callback = null)
	{
		string url = _baseUrl;
		await SendRequestWithAsync(url, method, bodyData, headers, callback);
	}

	private async Task SendRequestWithAsync(string url, SendRequestMethods method, string bodyData = "", Dictionary<string, string> headers = null, Action<HttpResponse> callback = null)
	{
		using (UnityWebRequest request = CreateRequest(url, method, bodyData, headers))
		{
			var tcs = new TaskCompletionSource<bool>();

			// Start the web request asynchronously
			var asyncOp = request.SendWebRequest();

			asyncOp.completed += operation =>
			{
				tcs.SetResult(true);
			};

			// Wait for the task to complete
			await tcs.Task;

			HttpResponse response = new HttpResponse(request);
			callback?.Invoke(response);
		}
	}

}
