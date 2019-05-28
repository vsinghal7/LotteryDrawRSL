using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FinalDrawResults()
        {
            DrawViewModel viewModel = new DrawViewModel()
            {
                MonWedLotto = true,
                OzLotto = true,
                Powerball = true,
                Super66 = true,
                TattsLotto = true,
                Draws = new Draw[] { new Draw() }
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult FinalDrawResults(DrawViewModel viewModel)
        {
            DrawViewModel drawViewModel = new DrawViewModel();

            var client = new RestClient("https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws");
            var request = new RestRequest(Method.POST);

            //Add Parameters
            request.AddHeader("content-length", "147");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "data.api.thelott.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("SearchCriteria",
                 "\r\n{\"CompanyId\":\"GoldenCasket\",\"MaxDrawCount\":20,\"OptionalProductFilter\":" +
                 "[ \"" + string.Join("\",\"", CreateFilters(viewModel)) + "\"]}", ParameterType.RequestBody);  //Create filters
            try
            {
                IRestResponse response = client.Execute(request);
                var model = JsonConvert.DeserializeObject<LotteryModel>(response.Content);
                if (model == null)
                    return new HttpNotFoundResult("NotFound");
                else
                {
                    drawViewModel = ResponseToDrawViewModelMapper(viewModel);
                    drawViewModel.Draws = model.Draws;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception has occurred.", ex);
            }

            return View(drawViewModel);
        }

        //To take input from user.
        private List<string> CreateFilters(DrawViewModel drawViewModel)
        {
            var filters = new List<string>();

            if (drawViewModel.MonWedLotto) filters.Add("MonWedLotto");
            if (drawViewModel.OzLotto) filters.Add("OzLotto");
            if (drawViewModel.Powerball) filters.Add("Powerball");
            if (drawViewModel.Super66) filters.Add("Super66");
            if (drawViewModel.TattsLotto) filters.Add("TattsLotto");

            return filters;
        }

        private DrawViewModel ResponseToDrawViewModelMapper(DrawViewModel drawViewModel)
        {
            var viewModel = new DrawViewModel()
            {
                MonWedLotto = drawViewModel.MonWedLotto,
                OzLotto = drawViewModel.OzLotto,
                Powerball = drawViewModel.Powerball,
                Super66 = drawViewModel.Super66,
                TattsLotto = drawViewModel.TattsLotto,                
            };

            return viewModel;
        }

    }
}