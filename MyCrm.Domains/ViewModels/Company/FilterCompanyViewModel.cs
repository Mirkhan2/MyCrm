using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.ViewModels.Paging;

namespace MyCrm.Domains.ViewModels.Company
{
    public class FilterCompanyViewModel : BasePaging
    {
        public string FilterCompanyName { get; set; }
        public List<Entities.Companies.Company> Companies { get; set; }
        public string FilterCompanyCode { get; set; }



        public FilterCompanyViewModel SetEntity(List<Entities.Companies.Company> comp)
        {
            this.Companies = comp;

            return this;
        }
        public FilterCompanyViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
    }
}
