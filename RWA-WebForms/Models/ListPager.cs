using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWA_WebForms.Models
{
	public class ListPager<T>
	{
		public ListPager(IList<T> listToWrap)
		{
			this._List = listToWrap;

			this._CurrentPage = 0;
			this.AmountPerPage = 10;
		}

		public int Page 
		{
			get => this._CurrentPage;
			set
			{
				this._CurrentPage = Math.Min(Math.Max(value, 0), this.LastPage - 1);
			}
		}
		public int AmountPerPage { get; set; }
		public int LastPage 
		{
			get => (this._List.Count / AmountPerPage) + 1;
		}

		public IList<T> GetList()
		{
			IList<T> Result = new List<T>();

			int startIndex = this.Page * this.AmountPerPage;
			for (int i = startIndex; i < Math.Min(startIndex + AmountPerPage, this._List.Count); ++i)
			{
				Result.Add(this._List[i]);
			}

			return Result;
		}

		private IList<T> _List;
		private int _CurrentPage;
	}
}
