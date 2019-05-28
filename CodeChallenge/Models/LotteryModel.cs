
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge
{
    public class LotteryModel
    {
        public Draw[] Draws { get; set; }
        public object ErrorInfo { get; set; }
        public bool Success { get; set; } 
    }

    public class Draw
    {
        public string ProductId { get; set; }

        [Display(Name = "Draw Number")]
        public int DrawNumber { get; set; }

        [Display(Name = "Draw Name")]
        public string DrawDisplayName { get; set; }

        [Display(Name = "Draw Date")]
        public DateTime DrawDate { get; set; }

        [Display(Name = "Logo")]
        public string DrawLogoUrl { get; set; }

        public string DrawType { get; set; }

        [Display(Name = "Jackpot Amount")]
        public double Div1Amount { get; set; }

        public bool IsDiv1Estimated { get; set; }

        public bool IsDiv1Unknown { get; set; }

        public DateTime DrawCloseDateTimeUTC { get; set; }

        public DateTime DrawEndSellDateTimeUTC { get; set; }

        public float DrawCountDownTimerSeconds { get; set; }
    }


    public class DrawViewModel
    {
        public DrawViewModel()
        {
            TattsLotto = true;
            MonWedLotto = true;
            OzLotto = true;
            Powerball = true;
            Super66 = true;
        }
        public bool TattsLotto { get; set; }
        public bool MonWedLotto { get; set; }
        public bool OzLotto { get; set; }
        public bool Powerball { get; set; }
        public bool Super66 { get; set; }
        public Draw[] Draws { get; set; }
    }

}