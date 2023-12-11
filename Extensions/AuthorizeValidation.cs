using fin_back.Models.Identity;
using System.Data;
using System.Text;
using System.Text.Json;

namespace fin_back.Extensions
{
    public class AuthorizeValidation
    {
        public static TokenClaims GetTokenPayload(string token)
        {
            string payload = token.Split('.')[1];

            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            payload = Encoding.UTF8.GetString(Convert.FromBase64String(payload));

            return JsonSerializer.Deserialize<TokenClaims>(payload);
        }

        public static Boolean TokenTimeValidation(string authToken) 
        {
            return DateTime.UnixEpoch.AddSeconds(GetTokenPayload(authToken).exp.Value) > DateTime.Now ? true : false;
        } 
    }
}
