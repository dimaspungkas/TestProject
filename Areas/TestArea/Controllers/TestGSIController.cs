using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.Areas.TestArea.Controllers
{
    public class TestGSIController : Controller
    {
        Dictionary<char, int> listKamus = 
            new Dictionary<char, int>{
                {'A', 0}, {'B', 1}, {'C', 1}, {'D', 1}, {'E', 2},
                {'F', 3}, {'G', 3}, {'H', 3}, {'I', 4}, {'J', 5},
                {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5}, {'O', 6},
                {'P', 7}, {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7},
                {'U', 8}, {'V', 9}, {'W', 9}, {'X', 9}, {'Y', 9}, {'Z', 9},
                {'a', 9}, {'b', 8}, {'c', 8}, {'d', 8}, {'e', 7},
                {'f', 6}, {'g', 6}, {'h', 6}, {'i', 5}, {'j', 4},
                {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4}, {'o', 3},
                {'p', 2}, {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2},
                {'u', 1}, {'v', 0}, {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0},
                {' ', 0}
            };

        // GET: TestArea/TestGSI
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetResultSoal1(string sampleInput)
        {
            try
            {
                List<int> result = new List<int>();

                foreach (char c in sampleInput)
                {
                    if (listKamus.ContainsKey(c))
                    {
                        result.Add(listKamus[c]);
                    }
                }
                string joinResult = string.Join(" ", result);
                return Json(new { success = true, data = joinResult });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetResultSoal2(string sampleInput)
        {
            try
            {
                var arrNum = sampleInput.Split(' ');
                int result = 0;
                string input = "";
                int i = 0;
                foreach (string c in arrNum)
                {
                    if (i % 2 == 0)
                    {
                        result = string.IsNullOrEmpty(input) ? Convert.ToInt32(c) : result - Convert.ToInt32(c);
                        input = string.IsNullOrEmpty(input) ? c : input + " - " + c;
                    }
                    else
                    {
                        result = string.IsNullOrEmpty(input) ? Convert.ToInt32(c) : result + Convert.ToInt32(c);
                        input = string.IsNullOrEmpty(input) ? c : input + " + " + c;
                    }
                    i++;
                }
                return Json(new { success = true, input = input, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetResultSoal3(int sampleInput)
        {
            try
            {
                int result = 0;
                string resultStr = "";
                string explanation = sampleInput.ToString();
                int i = 0;
                int sample = sampleInput;
                sampleInput = sampleInput < 0 ? sampleInput * -1 : sampleInput;
                explanation = sample < 0 ? explanation + " = " + sampleInput.ToString() + " = " : explanation + " = ";
                string explanation2 = "";
                for (int j = 0; i < sampleInput; j++)
                {
                    result += i;
                    char valChar = listKamus.FirstOrDefault(x => x.Value == i).Key;
                    if (result < sampleInput)
                    {
                        explanation2 = string.IsNullOrEmpty(explanation2) ? i.ToString() : explanation2 + " + " + i.ToString();
                        resultStr = string.IsNullOrEmpty(resultStr) ? valChar.ToString() : resultStr + valChar.ToString();
                        i++;
                    }
                    else if(result == sampleInput)
                    {
                        explanation2 = string.IsNullOrEmpty(explanation2) ? i.ToString() : explanation2 + " + " + i.ToString();
                        resultStr = string.IsNullOrEmpty(resultStr) ? valChar.ToString() : resultStr + valChar.ToString();
                        break;
                    }
                    else
                    {
                        result -= i;
                        i = 0;
                    }
                }

                explanation = explanation + explanation2;
                return Json(new { success = true, explanation = explanation, data = resultStr });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetResultSoal4(string sampleInput)
        {
            try
            {
                var arrNum = sampleInput.Split(' ');
                int result = 0;
                string input = "";

                List<int> resultChar = new List<int>();

                foreach (char c in sampleInput)
                {
                    if (listKamus.ContainsKey(c))
                    {
                        resultChar.Add(listKamus[c]);
                    }
                }

                foreach (int c in resultChar)
                {
                    result = string.IsNullOrEmpty(input) ? Convert.ToInt32(c) : result + Convert.ToInt32(c);
                    input = string.IsNullOrEmpty(input) ? c.ToString() : input + " + " + c.ToString();
                }

                int newresult = result;
                result += 2;
                result = result < 0 ? result * -1 : result;
                int result2 = 0;
                string resultStr = "";
                string explanation = "Hasil ditambah 2 \n" + input + " + 2 " + "\n" + result.ToString();
                int i = 0;
                explanation = newresult < 0 ? explanation + " = " + result.ToString() + " = " : explanation + " = ";
                string explanation2 = "";

                for (int j = 0; i < result; j++)
                {
                    result2 += i;
                    char valChar = listKamus.FirstOrDefault(x => x.Value == i).Key;
                    if (result2 < result)
                    {
                        explanation2 = string.IsNullOrEmpty(explanation2) ? i.ToString() : explanation2 + " + " + i.ToString();
                        resultStr = string.IsNullOrEmpty(resultStr) ? valChar.ToString() : resultStr + valChar.ToString();
                        i++;
                    }
                    else if (result2 == result)
                    {
                        explanation2 = string.IsNullOrEmpty(explanation2) ? i.ToString() : explanation2 + " + " + i.ToString();
                        resultStr = string.IsNullOrEmpty(resultStr) ? valChar.ToString() : resultStr + valChar.ToString();
                        break;
                    }
                    else if (newresult < result2 && i == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result2 -= i;
                        i = 0;
                    }
                }

                explanation = explanation + explanation2;
                return Json(new { success = true, explanation = explanation, data = resultStr });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetResultSoal5(string sampleInput)
        {
            try
            {
                int result = 0;
                string explanation = "";
                string input = "";
                List<int> resultChar = new List<int>();
                List<int> resultChar2 = new List<int>();

                foreach (char c in sampleInput)
                {
                    if (listKamus.ContainsKey(c))
                    {
                        int x = listKamus[c] % 2 == 0 ? listKamus[c] + 1 : listKamus[c];
                        resultChar.Add(x);
                        resultChar2.Add(listKamus[c]);
                    }
                }

                explanation = string.Join(" ", resultChar2);
                input = string.Join(" ", resultChar);
                explanation = explanation + "\nnumber mod 2 = 0 => +1\n" + input;
                return Json(new { success = true, explanation = explanation, data = input });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}