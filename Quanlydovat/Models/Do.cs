using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quanlydovat.Models
{
    public class Do
    {
        public int ID { set; get; }
        [Required(ErrorMessage ="vui long nhap ten")]
        public string Ten { set; get; }
        public string NguonG { set; get; }
        public string Gia { set; get; }
        [MinLength(2,ErrorMessage ="Vui long nhap du 2 ki tu")]
        public string DanhGia { set; get; }

    }
}