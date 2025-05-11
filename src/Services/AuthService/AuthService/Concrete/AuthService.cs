using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Adoroid.Core.Application.Exceptions.Types;
using AuthService.Abstracts;
using AuthService.Configs;
using AuthService.Requests;
using AuthService.Responses;
using IdentityManagementAPI.Services.Abstracts;
using AddUserToGroupRequestModel = AuthService.Requests.AddUserToGroupRequestModel;
using GetAccessTokenResponseModel = AuthService.Responses.GetAccessTokenResponseModel;
using GetGroupListByFilterRequest = AuthService.Requests.GetGroupListByFilterRequest;
using GroupRepresentationModel = AuthService.Models.GroupRepresentationModel;
using ResetPasswordModel = AuthService.Models.ResetPasswordModel;
using StatusModel = AuthService.Models.StatusModel;
using UpdateUserModel = AuthService.Models.UpdateUserModel;
using UserModel = AuthService.Models.UserModel;

namespace AuthService.Concrete;

public class AuthService(
    HttpClient httpClient,
    AuthServerInfo authServerInfo,
    ICurrentUserService userService)
    : IAuthService
{


    public async Task<AuthServerReponseModel<TokenResponseModel>?> GetAccesToken(string username, string password)
    {
        var request = new
        {
            username,
            password,
            grant_type = "password",
            client_id = authServerInfo.ClientId,
            client_secret = authServerInfo.ClientSecret
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/auth/login", content);

        var responseBody = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<AuthServerReponseModel<TokenResponseModel>>(responseBody);
        return tokenResponse;
    }

    public Task<bool> ValidateToken(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthServerReponseModel<StatusModel>?> Register(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/auth/register", content, cancellationToken);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var registerResponse = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return registerResponse;
    }

    public async Task<AuthServerReponseModel<StatusModel>?> Logout(LogoutRequest logoutRequest)
    {
        var json = JsonSerializer.Serialize(logoutRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/auth/logout", content);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<StatusModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync();
        var statusResponse = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return statusResponse;
    }

    public async Task<AuthServerReponseModel<StatusModel>?> UpdateUser(UpdateUserModel model)
    {
        model.Id = userService.Id!;
        var endpoint = $"{authServerInfo.AuthServerUrl}/user";
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        var json = JsonSerializer.Serialize(model);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");
        }

        var response = await httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<StatusModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync();
        var statusResponse = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return statusResponse;
    }

    public async Task<AuthServerReponseModel<StatusModel>?> ResetPassword(ResetPasswordModel model)
    {
        model.Type = "password";
        var endpoint = $"{authServerInfo.AuthServerUrl}/auth/reset-password";
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        var json = JsonSerializer.Serialize(model);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");

        var response = await httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<StatusModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync();
        var statusResponse = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return statusResponse;
    }

    public async Task<AuthServerReponseModel<StatusModel>?> ResetPasswordWithEmail()
    {
        var endpoint = $"{authServerInfo.AuthServerUrl}/auth/send-reset-password-email";
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");
        }

        var response = await httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<StatusModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync();
        var statusResponse = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return statusResponse;
    }

    public async Task<GetAccessTokenResponseModel> GetMainToken(CancellationToken cancellationToken)
    {
        var tokeEndPoint = $"{authServerInfo.HostName}/realms/{authServerInfo.Realm}/protocol/openid-connect/token";

        List<KeyValuePair<string, string>> data = [];
        KeyValuePair<string, string> grantType = new("grant_type", "client_credentials");
        KeyValuePair<string, string> clientId = new("client_id", authServerInfo.ClientId);
        KeyValuePair<string, string> clientSecret = new("client_secret", authServerInfo.ClientSecret);

        data.Add(grantType);
        data.Add(clientId);
        data.Add(clientSecret);

        var tokenResponse = await httpClient.PostAsync(tokeEndPoint, new FormUrlEncodedContent(data), cancellationToken);

        var responseStr = await tokenResponse.Content.ReadAsStringAsync(cancellationToken);

        var tokenModel = JsonSerializer.Deserialize<GetAccessTokenResponseModel>(responseStr)
                         ?? throw new CustomException(HttpStatusCode.BadRequest, "Error", "Cannot get token");

        return tokenModel;
    }
     
    public async Task<AuthServerReponseModel<List<UserModel>>?> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        
        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            var tokenModel = await GetMainToken(cancellationToken);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenModel.AccessToken}");
        }
        var endpoint = $"{authServerInfo.AuthServerUrl}/user/get-by-username/?username={username}";
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        var responseUserInfo = await httpClient.SendAsync(request, cancellationToken);

        if (responseUserInfo.StatusCode == HttpStatusCode.Forbidden)
            return new AuthServerReponseModel<List<UserModel>>
            {
                Data = null,
                Message = "Forbidden",
                Success = false,
                StatusCode = (int)responseUserInfo.StatusCode
            };

        if (responseUserInfo.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<List<UserModel>>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)responseUserInfo.StatusCode
            };

        var responseUserInfoBody = await responseUserInfo.Content.ReadAsStringAsync(cancellationToken);
        var userInfo = JsonSerializer.Deserialize<AuthServerReponseModel<List<UserModel>>>(responseUserInfoBody);
        return userInfo;
    }
    
    public async Task<AuthServerReponseModel<GroupRepresentationModel>?> AddGroup(GroupRepresentationModel model, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");
        }

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/group/add", content, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<GroupRepresentationModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var group = JsonSerializer.Deserialize<AuthServerReponseModel<GroupRepresentationModel>>(responseBody);
        return group;
    }
    
    public async Task<AuthServerReponseModel<List<GroupRepresentationModel>>?> GetGroups(GetGroupListByFilterRequest model, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");
        }

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/group/get-groups", content, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<List<GroupRepresentationModel>>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var groups = JsonSerializer.Deserialize<AuthServerReponseModel<List<GroupRepresentationModel>>>(responseBody);
        return groups;
    }
    
    
    public async Task<AuthServerReponseModel<StatusModel>?> AddUserToGroup(AddUserToGroupRequestModel model, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {userService.Token}");
        }

        var response = await httpClient.PostAsync($"{authServerInfo.AuthServerUrl}/group/add-user-to-group", content, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return new AuthServerReponseModel<StatusModel>
            {
                Data = null,
                Message = "Unauthorized",
                Success = false,
                StatusCode = (int)response.StatusCode
            };

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var status = JsonSerializer.Deserialize<AuthServerReponseModel<StatusModel>>(responseBody);
        return status;
    }
}