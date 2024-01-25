namespace BlogWebApp
{
    public class GlobalVar
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalVar()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:5281/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}