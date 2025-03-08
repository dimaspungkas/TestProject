using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.Areas.TestAreaBIT.Controllers
{
    public class Logika1Controller : Controller
    {
        // GET: TestAreaBIT/Logika1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logika2()
        {
            return View();
        }

        public ActionResult Logika5()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetLogika1(int inputVal, int[] inputArray)
        {
            bool success = false;
            string msg = "";
            int result = 0;
            try
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    for (int j = 0; j < inputArray.Length; j++)
                    {
                        result = inputArray[i] + inputArray[j];
                        if (i != j && inputVal == result && !success)
                        {
                            success = true;
                            msg = "[" + i + "," + j + "]";
                        }
                    }
                }

                return Json(new { success = success, message = msg });
            }
            catch (Exception ex)
            {
                return Json(new { success = success, message = ex.Message });
            }
        }
    }
}