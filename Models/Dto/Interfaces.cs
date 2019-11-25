using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Models.Dto
{
	[ExportTsInterface(OutputDir = "ts/interface")]
	public interface IComment
	{
		int Id { get; }
		string Content { get; }
	}

	[ExportTsInterface(OutputDir = "ts/interface")]
	public interface IVideoContent
	{
		int Id { get; }
		string Name { get; }
		int ReleaseYear { get; }
		string Description { get; }
		decimal? Rating { get; }
		string PosterUrl { get; }
		string FramesUrl { get; }
		IEnumerable<IComment> Comments { get; }
	}

	[ExportTsInterface(OutputDir = "ts/interface")]
	public interface ICinemaddict
	{
		int Id { get; }
		string FirstName { get; }
		string LastName { get; }
		string Email { get; }
		IEnumerable<IVideoContent> VideoContents { get; }
		IEnumerable<IConnection> Friends { get; }
	}

	[ExportTsInterface(OutputDir = "class")]
	public interface IConnection
	{
		int Id { get; }
		bool Notify { get; }
		ICinemaddict Friend { get; }
	}
}
