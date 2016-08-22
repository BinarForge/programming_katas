using System.Collections.Generic;
using System.Web.Http;
using JobberLib;
using System.Net.Http.Formatting;

namespace JobberDemoWebApp.Controllers
{
	public class ApiResponse
	{
		public string			Response;
		public bool				HasError;
		public List<string>		Errors = new List<string>();

		public void AddError(string errorMessage)
		{
			Errors.Add(errorMessage);
			HasError = true;
		}
	}

	public class ResolveJobsRequest
	{
		public Dictionary<char,string> Dependencies = new Dictionary<char, string>();
		public string JobSequence;
	}

	public class JobManagerController : ApiController
	{

		public ApiResponse Post([FromBody]ResolveJobsRequest data)
		{
			if (data == null) {
				return new ApiResponse { HasError = true, Errors = new List<string> { "No input data supplied!" } };
			}

			var jobber = new Jobber();
			jobber.Setup(data.Dependencies);

			try {
				return new ApiResponse 
				{
					Response = jobber.Resolve(data.JobSequence)
				};
			}
			catch(System.Exception e) {
				return new ApiResponse {
					Errors = new List<string> { e.Message },
					HasError = true
				};
			}
		}
	}
}