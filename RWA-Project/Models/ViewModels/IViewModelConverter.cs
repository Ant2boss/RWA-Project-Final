using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_Project.Models.ViewModels
{
	public interface IViewModelConverter<Target>
	{
		void SetFrom(Target val);

		Target ConvertBack();
	}
}
