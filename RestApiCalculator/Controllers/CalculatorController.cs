using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;

namespace RestApi_Udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/sum/5/5
        [HttpGet("sum/{fistNumber}/{secondNumber}")]
        public IActionResult Sum(string fistNumber, string secondNumber)
        {
            if (isNumeric(fistNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }
        //GET api/sub/5/5
        [HttpGet("sub/{fistNumber}/{secondNumber}")]
        public IActionResult Subtraction(string fistNumber, string secondNumber)
        {
            if(isNumeric(fistNumber) && isNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(fistNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid input");
        }
        //GET api/multi/5/5
        [HttpGet("multi/{fistNumber}/{secondNumber}")]
        public IActionResult Multi(string fistNumber, string secondNumber)
        {
            if(isNumeric(fistNumber) && isNumeric(secondNumber))
            {
                var multi = ConvertToDecimal(fistNumber) * ConvertToDecimal(secondNumber);
                return Ok(multi.ToString());
            }

            return BadRequest("Invalid input");
        }
        //GET api/div/5/5
        [HttpGet("div/{fistNumber}/{secondNumber}")]
        public IActionResult Division(string fistNumber, string secondNumber)
        {
            if (isNumeric(fistNumber) && isNumeric(secondNumber))
            {
                var division = ConvertToDecimal(fistNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid input");
        }

        //GET api/mean/5/5
        [HttpGet("mean/{fistNumber}/{secondNumber}")]
        public IActionResult Mean(string fistNumber, string secondNumber)
        {
            if (isNumeric(fistNumber) && isNumeric(secondNumber))
            {
                var mean = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid input");
        }

        //GET api/square-root/5
        [HttpGet("square-root/{fistNumber}")]
        public IActionResult SquareRoot(string fistNumber, string secondNumber)
        {
            if (isNumeric(fistNumber))
            {
                var sqr = Math.Sqrt((double)ConvertToDecimal(fistNumber));
                return Ok(sqr.ToString());
            }

            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
