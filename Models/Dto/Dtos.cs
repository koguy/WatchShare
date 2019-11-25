using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Models.Dto
{
	[ExportTsClass(OutputDir = "Models/ts/class")]
	public class Comment: IComment
	{
		public int Id { get; set; }
		public string Content { get; set; }
	}

	[ExportTsClass(OutputDir = "ts/class")]
	public class VideoContent: IVideoContent
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ReleaseYear { get; set; }
		public string Description { get; set; }
		public decimal? Rating { get; set; }
		public string PosterUrl { get; set; }
		public string FramesUrl { get; set; }
		public IEnumerable<IComment> Comments { get; set; }
	}

	[ExportTsClass(OutputDir = "ts/class")]
	public class Cinemaddict: ICinemaddict
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public IEnumerable<IVideoContent> VideoContents { get; set; }
		public IEnumerable<IConnection> Friends { get; set; }
	}

	[ExportTsClass(OutputDir = "ts/class")]
	public class Connection: IConnection
	{
		public int Id { get; set; }
		public ICinemaddict Friend { get; set; }
		public bool Notify { get; set; }
	}
}
