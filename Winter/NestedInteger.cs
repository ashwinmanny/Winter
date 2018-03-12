using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public interface NestedInteger
	{
		bool isInteger();

		int getInteger();

		List<NestedInteger> getList();
	}
}
