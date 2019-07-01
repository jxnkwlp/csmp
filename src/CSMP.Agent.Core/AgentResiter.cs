using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace CSMP.Agent
{
    public class AgentResiter
    {
        static HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

        public void Run()
        {
            string token = null;
            string serverUrl = null;
            string identifier = null;

            // ===== serverUrl =======
            serverUrl = ReadUserInput("请输入服务端地址：", (input) =>
            {
                if (!Uri.TryCreate(input, UriKind.Absolute, out var serverUri))
                {
                    Console.Write("服务端地址不合法!  ");
                    return false;
                }
                else
                {
                    return true;
                }
            });

            // ===== Token =======
            token = ReadUserInput("请输入Token：", (input) =>
            {
                return !string.IsNullOrWhiteSpace(input);
            });

            Console.Write("正在注册...");

            try
            {
                if (!serverUrl.EndsWith("/")) serverUrl += "/";

                var response = _httpClient.PostAsync($"{serverUrl}auth/agentregister?token={token}", new StringContent("", Encoding.UTF8)).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Console.Write("注册失败。Token 无效");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var result = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(content, new { identifier = "" });

                    identifier = result.identifier;
                }
                else
                {
                    Console.Write($"注册失败。(HttpStatusCode: {response.StatusCode})");
                }
            }
            catch (Exception ex)
            {
                Console.Write("注册失败。" + ex);
            }

            if (!string.IsNullOrWhiteSpace(identifier))
            {
                var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

                File.WriteAllText(file, Newtonsoft.Json.JsonConvert.SerializeObject(new { Identifier = identifier, ServerUrl = serverUrl, Token = token }));

                Console.Write("注册成功！请重新启动代理程序。");
            }
        }

        private string ReadUserInput(string promt, Func<string, bool> valid)
        {
            bool validResult = false;
            string input = null;

            while (!validResult)
            {
                Console.WriteLine("");
                Console.Write(promt);

                input = Console.ReadLine();

                validResult = valid(input);
            }

            return input;
        }
    }
}
