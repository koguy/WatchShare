using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Services
{
	public interface IVideoContentService
	{
		IEnumerable<VideoContent> List();
		IList<VideoContent> ListTop(int count);
		VideoContent Get(int id);
		VideoContent GetByName(string name);

	}
	public class VideoContentService : IVideoContentService
	{
		private WatchShareContext _context;
		public VideoContentService(WatchShareContext context)
		{
			_context = context;
		}

		public IEnumerable<VideoContent> List()
		{
			return _context.VideoContent.ToList();
		}

		public IList<VideoContent> ListTop(int count)
		{
			return _context.VideoContent.OrderByDescending(o => o.Rating).Take(count).ToList();
		}

		public VideoContent Get(int id)
		{
			return _context.VideoContent.FirstOrDefault(o => o.Id == id);
		}

		public VideoContent GetByName(string name)
		{
			return _context.VideoContent.FirstOrDefault(o => o.Name == name);
		}

	}
}
