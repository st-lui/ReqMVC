using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqMVC.Models.ViewModel
{
	public class RequestViewModel
	{
		public RequestViewModel(IEnumerable<RequestDTO> requestList)
		{
			RequestList = requestList;
		}

		public RequestViewModel()
		{
			RequestList = new List<RequestDTO>();
		}

		public IEnumerable<RequestDTO> RequestList { get; set; }
	}
}
