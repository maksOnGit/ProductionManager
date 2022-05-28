using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionLibrary;
using ProductionManager_EndProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProductionManager_EndProject.Models
{
    public class LotCreateOverviewModel
    {
        private readonly ProductRepository _productRepository;

        public LotCreateOverviewModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
            products = _productRepository.GetAll().ToList().ConvertAll(p => new SelectListItem { Value = p.Id.ToString(), Text = p.ProductName });
        }

        //This parameterless constructor is needed for create post action ! 
        public LotCreateOverviewModel()
        {

        }

        private IEnumerable<SelectListItem> products = new List<SelectListItem>();
        [Required(ErrorMessage = "Pleases select a product")]
        public IEnumerable<SelectListItem> Products
        {
            get
            {
                return products;
            }
            set { products = value; }
        }


        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please select a product or contact your admin if there is no product")]
        public int? ProductId { get; set; }
        public string Reference { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public bool? IsGrowing { get; set; }
        [Display(Name = "Recolted Quantitie")]
        public double RecoltedQuantitie { get; set; }
        [Required(ErrorMessage = "U need to provide an estimation (\"0\" is allowed)")]
        [RegularExpression(@"([0-9]{1,},[0-9]{1,}|[0-9]{1,})", ErrorMessage = "U need to use a number (use \",\" for decimal numbers)")]
        [Display(Name = "Estimated Quantitie")]
        public string EstimatedQuantitie { get; set; }
        
        //Navigation Properties
        public int ProductionId { get; set; }
        public Product Product { get; set; }
        public Room Room { get; set; }
    }
}
