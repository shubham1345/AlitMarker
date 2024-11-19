using Alit.Marker.Model;
using Alit.Marker.Service.Update.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Alit.Marker.DAL
{
    public static class WebFunctions
    {
        //public static HttpResponseMessage CallMarkerAdminURL(string URL)
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        HttpResponseMessage response = client.GetAsync(CommonProperties.MarkerAdminURL + URL).Result;
        //        response.EnsureSuccessStatusCode();
        //        return response;
        //    }
        //    catch(AggregateException)
        //    {
        //        return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.ServiceUnavailable };
        //    }
        //    catch(Exception)
        //    {
        //        return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError };
        //    }
        //}

        public static Alit.Marker.Service.Update.Model.PostResultViewModel<T> GetMarkerAdminAPI<T>(string URL)
        {
            HttpClient client = new HttpClient();
            PostResultViewModel<T> resultModel = null;
            try
            {
                HttpResponseMessage response = null;
                response = client.GetAsync(CommonProperties.MarkerAdminAPIURL + URL).Result;

                if (response.IsSuccessStatusCode)
                {
                    resultModel = response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<T>>().Result;
                }
                else
                {
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                    resultModel = new PostResultViewModel<T>();
                    resultModel.ErrorMessage = ErrMsg.Message;
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                resultModel = new PostResultViewModel<T>();
                resultModel.ErrorMessage = ex.Message;
            }
            return resultModel;
        }

        public static async Task<Alit.Marker.Service.Update.Model.PostResultViewModel<T>> GetMarkerAdminAPIAsync<T>(string URL)
        {
            HttpClient client = new HttpClient();
            PostResultViewModel<T> resultModel = null;
            try
            {
                var response = await client.GetAsync(CommonProperties.MarkerAdminAPIURL + URL);
                if (response.IsSuccessStatusCode)
                {
                    resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<T>>();
                }
                else
                {
                    var parseValue = await response.Content.ReadAsStringAsync();
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(parseValue);
                    resultModel = new PostResultViewModel<T>();
                    resultModel.ErrorMessage = ErrMsg.Message;
                }
            }
            //catch (System.Net.Http.HttpRequestException ex)
            //{
            //    DAL.CommonFunctions.GetFinalError(ex);
            //    resultModel.ErrorMessage = ex.Message;
            //}
            catch (Exception ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                resultModel = new PostResultViewModel<T>();
                resultModel.ErrorMessage = ex.Message;
            }
            return resultModel;
        }

        public static async Task<Alit.Marker.Service.Update.Model.PostResultViewModel<ResultType>> PostMarkerAdminAPIAsync<ContentType, ResultType>(string URL, ContentType content)
        {
            HttpClient client = new HttpClient();
            PostResultViewModel<ResultType> resultModel = null;
            try
            {
                var response = await client.PostAsJsonAsync<ContentType>(CommonProperties.MarkerAdminAPIURL + URL, content);
                if (response.IsSuccessStatusCode)
                {
                    resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<ResultType>>();
                }
                else
                {
                    var parseValue = await response.Content.ReadAsStringAsync();
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(parseValue);
                    resultModel = new PostResultViewModel<ResultType>();
                    resultModel.ErrorMessage = ErrMsg.Message;
                }
            }
            //catch (System.Net.Http.HttpRequestException ex)
            //{
            //    DAL.CommonFunctions.GetFinalError(ex);
            //    resultModel.ErrorMessage = ex.Message;
            //}
            catch (Exception ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                resultModel = new PostResultViewModel<ResultType>();
                resultModel.ErrorMessage = ex.Message;
            }
            return resultModel;
        }
    }
}
